using System;
using SweetGame.CodeBase.Animators;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    [RequireComponent(typeof(AnimatorBase))]
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public AnimatorBase EnemyAnimatorBase;
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
            EnemyAnimatorBase.PlayDamage();
            ChangeHealth?.Invoke();
        }
    }
}