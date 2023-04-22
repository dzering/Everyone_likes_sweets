using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.CodeBase.StaticData
{
    [CreateAssetMenu(fileName = nameof(LevelStaticData), menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;

        public List<EnemySpawnerData> EnemySpawnersData;
    }
}