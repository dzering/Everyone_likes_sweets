using UnityEngine;
using SweetGame.Abstractions;
using SweetGame.Abstractions.Base;
using UnityEngine.Events;
using System;

namespace SweetGame.Player
{
    internal sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] public float Gravity = - 9.81f;
        [SerializeField] public float JumpForce = 10;

        private UnityAction OnDeath;

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
