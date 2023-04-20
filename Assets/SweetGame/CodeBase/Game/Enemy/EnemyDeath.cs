using System;
using System.Collections;
using SweetGame.CodeBase.Animators;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    [RequireComponent(typeof(EnemyAnimator), typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        public event Action OnDeath;
        
        public EnemyAnimator Animator;
        public EnemyHealth Health;
        public GameObject DeathFx;


        private void Start() => 
            Health.ChangeHealth += OnChangeHealth;

        private void OnDestroy() => 
            Health.ChangeHealth -= OnChangeHealth;

        private void OnChangeHealth()
        {
            if(Health.CurrentHealth > 0)
                return;

            Die();
        }

        private void Die()
        {
            Health.ChangeHealth -= OnChangeHealth;
            SpawnDeathFx();
            Animator.PlayDeath();
            OnDeath?.Invoke();
            StartCoroutine(DestroyTimer());
        }

        private void SpawnDeathFx() => 
            Instantiate(DeathFx, transform.position, Quaternion.identity);

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    }
}