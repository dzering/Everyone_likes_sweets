using System;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerObserver : MonoBehaviour
    {
        public Action<Collider2D> TriggerEnter;
        public Action<Collider2D> TriggerExit;
        private void OnTriggerEnter2D(Collider2D other) => 
            TriggerEnter?.Invoke(other);

        private void OnTriggerExit2D(Collider2D other) =>
            TriggerExit?.Invoke(other);
    }
}