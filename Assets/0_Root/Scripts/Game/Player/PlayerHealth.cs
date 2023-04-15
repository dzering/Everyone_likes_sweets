using System;
using SweetGame.Enemy;
using UnityEngine;

namespace SweetGame.Game.Sweets
{
    public class PlayerHealth : MonoBehaviour, ISavedProgress
    {
        public Action OnChangeHealth;
        private Health _health;

        public float MaxHealth
        {
            get => _health.MaxHealth; 
            set => _health.MaxHealth = value;
        }

        public float CurrentHealth
        {
            get => _health.CurrentHealth;
            set
            {
                if(_health.CurrentHealth != value)
                {
                    _health.CurrentHealth = value;
                    OnChangeHealth?.Invoke();
                }
            }
        }

        [SerializeField] private PlayerAnimator _animator;

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _health = playerProgress.Health;
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.Health.CurrentHealth = CurrentHealth;
            playerProgress.Health.MaxHealth = MaxHealth;
            OnChangeHealth?.Invoke();
        }

        public void TakeDamage(float damage)
        {
            if(CurrentHealth<0)
                return;
            
            CurrentHealth -= damage;
            _animator.PlayHurt();
        }
    }
}