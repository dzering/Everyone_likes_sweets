using UnityEngine;
using System;


namespace SweetGame.Data.Spawner
{
    [CreateAssetMenu(fileName = nameof(SpawnPointsConfig), menuName = "SweetGame/Spawner/" + nameof(SpawnPointsConfig))]
    public class SpawnPointsConfig : ScriptableObject
    {
        [SerializeField] public SpawnPoint[] SpawnPoints;
    }

    [Serializable]
    public struct SpawnPoint
    {
        public TypeEnemy TypeEnemy;
        public Vector2 position;
    }

    public enum TypeEnemy
    {
        Fly = 0,
        Groung = 1
    }
}
