using System;


namespace SweetGame.CodeBase.Data
{
    [Serializable]
    public class Health
    {
        public float MaxHealth;
        public float CurrentHealth;

        public void ResetHealth() => CurrentHealth = MaxHealth;
    }
}