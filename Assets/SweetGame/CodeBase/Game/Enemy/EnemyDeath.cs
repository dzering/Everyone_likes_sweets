using System;
using System.Collections;
using SweetGame.CodeBase.Animators;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    [RequireComponent(typeof(AnimatorBase), typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        public event Action OnDeath;

        public AnimatorBase AnimatorBase;
        public EnemyHealth Health;
        public GameObject DeathFx;


        private void Start() => 
            Health.ChangeHealth += OnChangeHealth;

        private void OnDestroy()
        {
            Health.ChangeHealth -= OnChangeHealth;
        }

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
            AnimatorBase.PlayDeath();
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