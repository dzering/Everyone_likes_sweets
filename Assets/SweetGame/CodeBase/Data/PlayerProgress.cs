using System;

namespace SweetGame.CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public Health Health;
        public WorldData WordData;
        public AudioData AudioData;


        public PlayerProgress(string initialLevel)
        {
            Health = new Health();
            WordData = new WorldData(initialLevel);
            AudioData = new AudioData();
        }
    }
}