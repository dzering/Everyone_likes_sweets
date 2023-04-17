using System;
using System.Collections.Generic;
using SweetGame.CodeBase.Enum;
using UnityEngine;

namespace SweetGame.CodeBase.Data.Spawner
{
    [CreateAssetMenu(fileName = nameof(SpawnPointsConfig), menuName = "SweetGame/Spawner/" + nameof(SpawnPointsConfig))]
    public class SpawnPointsConfig : ScriptableObject
    {
        [SerializeField] public SpawnPoint[] SpawnPoints;

        public List<SpawnPoint> GetStackOfPoints(EnemyMovingType type)
        {
            List<SpawnPoint> stack = new List<SpawnPoint>();

            for (int i = 0; i < SpawnPoints.Length; i++)
            {
                if (SpawnPoints[i].TypeEnemy == type)
                {
                    stack.Add(SpawnPoints[i]);
                }
            }
            return stack;
        }
    }


    [Serializable]
    public struct SpawnPoint
    {
        public EnemyMovingType TypeEnemy;
        public Vector2 position;
    }

}
