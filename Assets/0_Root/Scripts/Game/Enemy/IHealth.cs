using System;

namespace SweetGame.Game.Enemy
{
    public interface IHealth
    {
        event Action ChangeHealth;
        float Health { get; set; }
        float CurrentHealth { get; set; }
        void TakeDamage(float damage);
    }
}