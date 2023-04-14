using System;

namespace SweetGame
{
    [Serializable]
    public class Health
    {
        public float MaxHealth;
        public float CurrentHealth;

        public void ResetHealth() => CurrentHealth = MaxHealth;
    }
}