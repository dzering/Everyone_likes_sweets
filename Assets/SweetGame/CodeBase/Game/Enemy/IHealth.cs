using System;

namespace SweetGame.CodeBase.Game.Enemy
{
    public interface IHealth
    {
        event Action ChangeHealth;
        float MaxHealth { get; set; }
        float CurrentHealth { get; set; }
        void TakeDamage(float damage);
    }
}