using System;
using SweetGame.Game.Sweets;
using Unity.VisualScripting;
using UnityEngine;

namespace SweetGame.Enemy.States
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