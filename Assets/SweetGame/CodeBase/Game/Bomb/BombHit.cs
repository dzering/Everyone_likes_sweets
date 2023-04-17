using SweetGame.CodeBase.Game.Enemy;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Bomb
{
    public class BombHit : MonoBehaviour
    {
        public float Damage;
        public float ExplosureRadius = 2;
        public GameObject ExplosureVFX;
        public TriggerObserver TriggerObserver;
        private int _layerMask;
        private readonly Collider2D[] _hits = new Collider2D[3];

        private void Start()
        {
            _layerMask = 1 << LayerMask.NameToLayer("IsHit");
            TriggerObserver.TriggerEnter += OnExplosure;
        }

        private void OnExplosure(Collider2D obj)
        {
            SpawnExplosionFx();
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

        private void SpawnExplosionFx() => 
            Instantiate(ExplosureVFX, transform.position, Quaternion.identity);

        public int Hit()=> 
            Physics2D.OverlapCircleNonAlloc(StartPoint(), ExplosureRadius, _hits, _layerMask);

        private Vector2 StartPoint() => 
            transform.position;
    }
}