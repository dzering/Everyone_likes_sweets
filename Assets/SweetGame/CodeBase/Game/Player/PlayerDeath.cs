using SweetGame.CodeBase.Animators;
using Unity.Mathematics;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        public PlayerHealth PlayerHealth;
        public PlayerAnimator PlayerAnimator;
        public PlayerMove PlayerMove;
        public PlayerAttack PlayerAttack;
        
        public GameObject DieVFX;
        
        private bool _isDead;

        private void Start() => 
            PlayerHealth.ChangeHealth += HealthChange;

        private void OnDestroy() => 
            PlayerHealth.ChangeHealth -= HealthChange;

        private void HealthChange()
        {
            if (!_isDead && PlayerHealth.CurrentHealth <= 0) 
                Die();
        }

        private void Die()
        {
            _isDead = true;
            PlayerMove.enabled = false;
            PlayerAttack.enabled = false;
            PlayerAnimator.PlayDie();
            Instantiate(DieVFX, transform.position, quaternion.identity);
        }
    }
}