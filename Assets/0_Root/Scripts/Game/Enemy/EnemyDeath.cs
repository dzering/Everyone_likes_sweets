using System;
using System.Collections;
using SweetGame.Enemy;
using UnityEngine;

namespace SweetGame.Game.Enemy
{
    [RequireComponent(typeof(EnemyAnimator), typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        public EnemyAnimator Animator;
        public EnemyHealth Health;
        public GameObject DeathFx;

        public event Action OnDeath;

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