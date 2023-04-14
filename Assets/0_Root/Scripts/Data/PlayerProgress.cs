using System;
using UnityEngine;

namespace SweetGame
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WordData;
        public Health Health { get; set; }


        public PlayerProgress(string initialLevel)
        {
            WordData = new WorldData(initialLevel);
            Health = new Health();
        }
    }
}