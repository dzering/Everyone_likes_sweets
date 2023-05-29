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
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
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

        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriter.Clear();
        }

        public GameObject CreatePlayer()
        {
            Player = InstantiateRegister(AssetPath.PLAYER_PATH);
            return Player;
        }

        public GameObject CreateHUD()
        {
            GameObject hud = InstantiateRegister(AssetPath.HUD_PATH);
            hud.GetComponentInChildren<LootCounter>().Construct(_progressService.PlayerProgress.WordData);
            hud.GetComponentInChildren<SceneButton>().Construct(_stateMachine);
            
            return hud;
        }

        public async Task<GameObject> CreateEnemy(EnemyTypeId enemyTypeId, Transform parent)
        {
            EnemyStaticData enemyData = _staticData.ForEnemy(enemyTypeId);

            AsyncOperationHandle<GameObject> 
                handle = Addressables.LoadAssetAsync<GameObject>(enemyData.PrefabReference);

            GameObject prefab = await handle.Task;

            Addressables.Release(prefab);

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

        public void CreateDestructor(string destructorId, Vector3 position)
        {
            Destructor destructor = InstantiateRegister(AssetPath.DESTRUCTOR_PATH, position).GetComponent<Destructor>();
            destructor.ID = destructorId;
        }

        public void CreateSpawner(List<ISpawnPoint> spawnPoints, ICoroutineRunner coroutine)
        {
            GameObject spawnerGO = InstantiateRegister(AssetPath.SPAWNER);
            Spawner spawner = spawnerGO.GetComponentInChildren<Spawner>();
            spawner.Construct(spawnPoints);
        }

        public IAudioManager CreateAudioManager()
        {
            GameObject audioService = InstantiateRegister(AssetPath.AUDIO_MANAGER);
            return audioService.GetComponent<IAudioManager>();
        }

        public SpawnPoint CreateSpawnPoint(string spawnerId, EnemyTypeId enemyTypeId, Vector3 position)
        {
            SpawnPoint spawnPoint = InstantiateRegister(AssetPath.SPAWNER_POINTS_PATH, position)
                .GetComponent<SpawnPoint>();
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

        public LootPiece CrateLoot()
        {
            var lootPiece = InstantiateRegister(AssetPath.LOOT_PATH).GetComponent<LootPiece>();
            lootPiece.Construct(_progressService.PlayerProgress.WordData);
            return lootPiece;
        }

        public void CreateBackground()
        {
            GameObject Background = InstantiateRegister(AssetPath.BACKGROUND_PATH);
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

        private void RegisterProgressWatchers(GameObject player)
        {
            foreach (ISavedProgressReader progressReader in player.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }
    }
}