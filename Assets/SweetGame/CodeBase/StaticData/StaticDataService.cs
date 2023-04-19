using System.Collections.Generic;
using System.Linq;
using SweetGame.CodeBase.Game.Spawner;
using UnityEngine;

namespace SweetGame.CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string PATH = "StaticData/EnemyStaticData";
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemies;

        public void LoadEnemies() =>
            _enemies = Resources
                .LoadAll<EnemyStaticData>(PATH)
                .ToDictionary(x => x.EnemyTypeId, x => x);

        public EnemyStaticData ForEnemy(EnemyTypeId enemyTypeId) => 
            _enemies.TryGetValue(enemyTypeId, out EnemyStaticData staticData) 
                ? staticData 
                : null;
    }
}