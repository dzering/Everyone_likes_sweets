using System;
using SweetGame.Enemy;
using UnityEngine;

namespace SweetGame.Game.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public EnemyAnimator EnemyAnimator;
        private float _health;
        private float _currentHealth;

        public event Action ChangeHealth ;

        public float Health
        {
            get => _health;
            set => _health = value;
        }

        public float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        public void TakeDamage(float damage)
        {
            if (CurrentHealth > 0)
            {
                CurrentHealth -= damage;
                EnemyAnimator.PlayHurt();
                ChangeHealth?.Invoke();
            }
        }
    }
}