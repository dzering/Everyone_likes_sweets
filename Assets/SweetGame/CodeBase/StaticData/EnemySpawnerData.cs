using System;
using SweetGame.CodeBase.Game.Spawner;
using Vector3 = UnityEngine.Vector3;

namespace SweetGame.CodeBase.StaticData
{
    [Serializable]
    public class EnemySpawnerData
    {
        public string SpawnerId;
        public EnemyTypeId EnemyTypeId;
        public Vector3 Position;

        public EnemySpawnerData(string spawnerId, EnemyTypeId enemyTypeId, Vector3 position)
        {
            SpawnerId = spawnerId;
            EnemyTypeId = enemyTypeId;
            Position = position;
        }
    }
}