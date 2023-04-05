using System;
using UnityEngine;

namespace SweetGame
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WordData;

        public PlayerProgress(string initialLevel)
        {
            WordData = new WorldData(initialLevel);
        }
    }
}