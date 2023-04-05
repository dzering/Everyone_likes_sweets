using System;
using UnityEngine.Serialization;

namespace SweetGame
{
    [Serializable]
    public class PositionOnLevel
    {
        [FormerlySerializedAs("LevelName")] public string Level;
        public Vector3Data Position;

        public PositionOnLevel(string level, Vector3Data position)
        {
            Level = level;
            Position = position;
        }
    }
}