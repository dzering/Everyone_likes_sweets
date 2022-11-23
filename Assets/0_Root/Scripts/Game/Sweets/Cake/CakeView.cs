using UnityEngine;
using SweetGame.Abstractions;
using UnityEngine.Events;

namespace SweetGame.Game.Sweets
{
    internal sealed class CakeView : PlayerViewBase
    {
        private UnityAction OnDeath;

        [SerializeField] public float Gravity = - 9.81f;
        [SerializeField] public float JumpForce = 10;

        public void Init(UnityAction action)
        {
            OnDeath += action;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out InteractiveObject interactible))
            {
                interactible.Interaction();
            }

            if (interactible is EnemyBase)
            {
                OnDeath?.Invoke();
            }
        }

    }
}
