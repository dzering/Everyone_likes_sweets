using System;
using System.Collections.Generic;
using SweetGame.CodeBase.Data;
using SweetGame.CodeBase.Game.Enemy;
using SweetGame.CodeBase.Game.Enemy.AI;
using SweetGame.CodeBase.Game.Spawner;
using SweetGame.CodeBase.Infrastructure.AssetMenegment;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.StaticData;
using SweetGame.CodeBase.UI;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        private IStaticDataService _staticData;

        public GameFactory(IAssets assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public List<ISavedProgress> ProgressWriter { get; } = new List<ISavedProgress>();
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();

        public GameObject Player { get; private set; }

        public GameObject CreatePlayer()
        {
            Player = InstantiateRegister(AssetPath.PLAYER_PATH);
            return Player;
        }

        public GameObject CreateHUD() => InstantiateRegister(AssetPath.HUD_PATH);

        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriter.Clear();
        }

        public GameObject CreateEnemy(EnemyTypeId enemyTypeId, Transform parent)
        {
            EnemyStaticData enemyData = _staticData.ForEnemy(enemyTypeId);
            GameObject enemy = Object.Instantiate(enemyData.Prefab, parent.position, quaternion.identity);
            
            IHealth health = enemy.GetComponent<IHealth>();
            
            health.CurrentHealth = enemyData.Health;
            health.MaxHealth = enemyData.Health;
            enemy.GetComponent<RegisterPlayer>().Construct(Player.gameObject.transform);

            Attack attack = enemy.GetComponent<Attack>();
            attack.Construct(Player.gameObject.transform);
            attack.Damage = enemyData.Damage;
            attack.CoolDownTime = enemyData.CoolDownTimeAttack;
            attack.EffectiveDistance = enemyData.AttackRadius;

            return enemy;
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
            {
                Register(progressReader);
            }
        }

        public void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                ProgressWriter.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    }
}