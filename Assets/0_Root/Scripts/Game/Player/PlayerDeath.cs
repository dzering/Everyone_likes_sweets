using System;
using SweetGame.Enemy;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.Game.Sweets
{
    public class PlayerDeath : MonoBehaviour
    {
        public PlayerHealth PlayerHealth;
        public PlayerAnimator PlayerAnimator;
        public PlayerMove PlayerMove;
        
        public GameObject DieVFX;
        
        private bool _isDead;

        private void Start() => 
            PlayerHealth.OnChangeHealth += HealthChange;

        private void OnDestroy() => 
            PlayerHealth.OnChangeHealth -= HealthChange;

        private void HealthChange()
        {
            if (!_isDead && PlayerHealth.CurrentHealth <= 0) 
                Die();
        }

        private void Die()
        {
            _isDead = true;
            PlayerMove.enabled = false;
            PlayerAnimator.PlayDie();
            Instantiate(DieVFX, transform.position, quaternion.identity);
        }
    }
}