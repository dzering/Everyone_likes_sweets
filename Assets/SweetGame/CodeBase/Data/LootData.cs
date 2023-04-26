using System;

namespace SweetGame.CodeBase.Data
{
    [Serializable]
    public class LootData
    {
        public int Collected;
        public Action ChangeLoot;

        public void Collect(Loot loot)
        {
            Collected += loot.Value;
            ChangeLoot?.Invoke();
        } 
        public void Add(int loot)
        {
            Collected += loot;
            ChangeLoot?.Invoke();
        }
    }
}