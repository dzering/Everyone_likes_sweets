using System.Collections.Generic;
using System.Threading.Tasks;
using SweetGame.CodeBase.Audio;
using SweetGame.CodeBase.Game.Counter;
using SweetGame.CodeBase.Game.Enemy;
using SweetGame.CodeBase.Game.Enemy.AI;
using SweetGame.CodeBase.Game.Spawner;
using SweetGame.CodeBase.Infrastructure.AssetManagement;
using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Infrastructure.States;
using SweetGame.CodeBase.StaticData;
using SweetGame.CodeBase.UI.Elements;
using SweetGame.CodeBase.UI.Menu;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;
        private readonly IRandomService _randomService;
        private readonly IProgressService _progressService;
        private readonly GameStateMachine _stateMachine;

        public List<ISavedProgress> ProgressWriter { get; } = new List<ISavedProgress>();
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();

        public GameObject Player { get; private set; }

        public GameFactory(IAssets assets, IStaticDataService staticData, IRandomService randomService,
            IProgressService progressService, GameStateMachine stateMachine)
        {
            _assets = assets;
            _staticData = staticData;
            _randomService = randomService;
            _progressService = progressService;
            _stateMachine = stateMachine;
        }

        public async Task WarmUp()
        {
            await _assets.Load<GameObject>(AssetAddress.LOOT);
            await _assets.Load<GameObject>(AssetAddress.SPAWN_POINT);
        }

        public async Task WarmUpUI()=>
            await _assets.Load<GameObject>(AssetAddress.UI_ROOT);

        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriter.Clear();
            _assets.CleanUp();
        }

        public async Task<LootPiece> CrateLoot()
        {
            GameObject prefab = await _assets.Load<GameObject>(AssetAddress.LOOT);
            GameObject instantiateRegister = InstantiateRegisterAsync(prefab);
            LootPiece lootPiece = instantiateRegister.GetComponent<LootPiece>();
            lootPiece.Construct(_progressService.PlayerProgress.WordData);
            return lootPiece;
        }

        public GameObject CreatePlayer()
        {
            Player = InstantiateRegister(AssetAddress.PLAYER_PATH);
            return Player;
        }

        public async Task<GameObject> CreateHUD()
        {
            GameObject prefab = await _assets.Load<GameObject>(AssetAddress.HUD);
            GameObject hud = InstantiateRegisterAsync(prefab);
            hud.GetComponentInChildren<LootCounter>().Construct(_progressService.PlayerProgress.WordData);
            hud.GetComponentInChildren<SceneButton>().Construct(_stateMachine);
            
            return hud;
        }

        public async Task<GameObject> CreateEnemy(EnemyTypeId enemyTypeId, Transform parent)
        {
            EnemyStaticData enemyData = _staticData.ForEnemy(enemyTypeId);
            GameObject prefab = await _assets.Load<GameObject>(enemyData.PrefabReference);
            GameObject enemy = Object.Instantiate(prefab, parent.position, quaternion.identity);
            
            IHealth health = enemy.GetComponent<IHealth>();
            
            health.CurrentHealth = enemyData.Health;
            health.MaxHealth = enemyData.Health;
            enemy.GetComponent<RegisterPlayer>().Construct(Player.gameObject.transform);

            Attack attack = enemy.GetComponent<Attack>();
            attack.Construct(Player.gameObject.transform);
            attack.Damage = enemyData.Damage;
            attack.CoolDownTime = enemyData.CoolDownTimeAttack;
            attack.EffectiveDistance = enemyData.AttackRadius;

            LootSpawner lootSpawner = enemy.GetComponentInChildren<LootSpawner>();
            lootSpawner.Construct(this, _randomService);
            lootSpawner.SetLoot(enemyData.LootMin, enemyData.LootMax);

            Counter counter = enemy.GetComponentInChildren<Counter>();
            counter.Constract(_progressService);

            return enemy;
        }

        public async void CreateDestructor(string destructorId, Vector3 position)
        {
            GameObject prefab = await _assets.Load<GameObject>(AssetAddress.DESTRUCTOR);
            Destructor destructor = InstantiateRegisterAsync(prefab, position).GetComponent<Destructor>();
            destructor.ID = destructorId;
        }

        public async void CreateSpawner(List<ISpawnPoint> spawnPoints, ICoroutineRunner coroutine)
        {
            GameObject prefab = await _assets.Load<GameObject>(AssetAddress.SPAWNER);
            GameObject spawnerGo = InstantiateRegisterAsync(prefab);
            Spawner spawner = spawnerGo.GetComponentInChildren<Spawner>();
            spawner.Construct(spawnPoints);
        }

        public IAudioManager CreateAudioManager()
        {
            GameObject audioService = InstantiateRegister(AssetPath.AUDIO_MANAGER);
            return audioService.GetComponent<IAudioManager>();
        }

        public async Task<SpawnPoint> CreateSpawnPoint(string spawnerId, EnemyTypeId enemyTypeId, Vector3 position)
        {
            GameObject prefab = await _assets.Load<GameObject>(AssetAddress.SPAWN_POINT);
            SpawnPoint spawnPoint = InstantiateRegisterAsync(prefab, position).GetComponent<SpawnPoint>();
            spawnPoint.Construct(this);
            spawnPoint.EnemyTypeId = enemyTypeId;
            spawnPoint.Id = spawnerId;
            return spawnPoint;
        }

        public void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                ProgressWriter.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }

        public async void CreateBackground()
        {
            GameObject prefab = await _assets.Load<GameObject>(AssetAddress.BACKGROUND);
            InstantiateRegisterAsync(prefab);
        }

        private GameObject InstantiateRegister(string prefabPath, Vector3 position)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, position);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private GameObject InstantiateRegister(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
        
        private GameObject InstantiateRegisterAsync(GameObject prefab)
        {
            GameObject gameObject = Object.Instantiate(prefab);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
        
        private GameObject InstantiateRegisterAsync(GameObject prefab, Vector3 position)
        {
            GameObject gameObject = Object.Instantiate(prefab, position, Quaternion.identity);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject player)
        {
            foreach (ISavedProgressReader progressReader in player.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }
    }
}