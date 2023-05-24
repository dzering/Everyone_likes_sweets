using System;

namespace SweetGame.CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public Health Health;
        public WorldData WordData;


        public PlayerProgress(string initialLevel)
        {
            Health = new Health();
            WordData = new WorldData(initialLevel);
        }
    }
}