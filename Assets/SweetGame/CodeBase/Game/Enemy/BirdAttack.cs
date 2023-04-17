using SweetGame.CodeBase.Game.Player;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    public class BirdAttack : MonoBehaviour
    {
        public float Damage = 100;
        public TriggerObserver TriggerObserver;

        private void Start() => 
            TriggerObserver.TriggerEnter += GiveDamage;

        private void GiveDamage(Collider2D obj)
        {
            if(obj.TryGetComponent(out PlayerHealth playerHealth))
                   playerHealth.TakeDamage(Damage);
        }
    }
}