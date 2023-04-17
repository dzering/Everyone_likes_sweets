using System;
using SweetGame.CodeBase.Animators;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public EnemyAnimator EnemyAnimator;
        private float _health;
        private float _currentHealth = 10f;

        public event Action ChangeHealth;

        public float MaxHealth
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
            if (CurrentHealth < 0)
                return;

            CurrentHealth -= damage;
            EnemyAnimator.PlayHurt();
            ChangeHealth?.Invoke();
        }
    }
}