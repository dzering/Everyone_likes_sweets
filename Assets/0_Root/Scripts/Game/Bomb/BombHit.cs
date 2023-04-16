using System;
using SweetGame.Enemy;
using SweetGame.Game.Enemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.Game.Player
{
    public class BombHit : MonoBehaviour
    {
        public float Damage;
        private int _layerMask;
        private readonly Collider2D[] _hits = new Collider2D[3];
        public float ExplosureRadius = 2;
        public GameObject ExplosureVFX;
        public TriggerObserver TriggerObserver;

        private void Start()
        {
            _layerMask = 1 << LayerMask.NameToLayer("IsHit");
            TriggerObserver.TriggerEnter += OnExplosure;
        }

        private void OnExplosure(Collider2D obj)
        {
            InstantiateEffect();
            DamageTargets();
            Destroy(gameObject);
        }

        private void DamageTargets()
        {
            for (int i = 0; i < Hit(); i++)
            {
                _hits[i].transform.parent.GetComponent<IHealth>().TakeDamage(Damage);
            }
        }

        private void InstantiateEffect() => 
            Instantiate(ExplosureVFX, transform.position, Quaternion.identity);

        public int Hit()=> 
            Physics2D.OverlapCircleNonAlloc(StartPoint(), ExplosureRadius, _hits, _layerMask);

        private Vector2 StartPoint() => 
            transform.position;
    }
}