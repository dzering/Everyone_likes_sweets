using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    [RequireComponent(typeof(Attack))]
    public class CheckAttackRange : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public Attack Attack;


        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;

            Attack.AttackEnable();
        }

        private void TriggerExit(Collider2D obj)
        {
            Attack.AttackDisable();
        }

        private void TriggerEnter(Collider2D obj)
        {
            Attack.AttackEnable(); 
        }
    }
}