using System.Collections.Generic;
using System.Linq;
using SweetGame.CodeBase.Game.Spawner;
using UnityEngine;

namespace SweetGame.CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string PATH_ENEMIES = "StaticData/EnemyStaticData";
        private const string PATH_LEVELS = "StaticData/Levels";
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemies;
        private Dictionary<string, LevelStaticData> _levels;

        public void LoadEnemies() =>
            _enemies = Resources
                .LoadAll<EnemyStaticData>(PATH_ENEMIES)
                .ToDictionary(x => x.EnemyTypeId, x => x);

        public EnemyStaticData ForEnemy(EnemyTypeId enemyTypeId) => 
            _enemies.TryGetValue(enemyTypeId, out EnemyStaticData staticData) 
                ? staticData 
                : null;
        
        public void LoadSpawners() =>
            _levels = Resources
                .LoadAll<LevelStaticData>(PATH_LEVELS)
                .ToDictionary(x => x.LevelKey, x => x);


        public LevelStaticData ForLevel(string sceneKey)=>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData) 
                ? staticData 
                : null;
    }
}