using System;
using SweetGame.CodeBase.Enum;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy.Bird
{
    public sealed class BirdView : MonoBehaviour
    {
        public Action OnCatchPlayer;   
        public event Action<InteractionType> OnInteraction;
        private void Start()
        {
            //SpriteAnimator.instance.StartAnimation(GetComponent<SpriteRenderer>(), Track.Bird_1_fly, true, 10);
        }

        private void OnDestroy()
        {
           // SpriteAnimator.instance.StopAnimation(GetComponent<SpriteRenderer>());
        }

        private void OnTriggerEnter(Collider other)
        {
            OnCatchPlayer?.Invoke();
        }

        public void Interaction(InteractionType type)
        {
            OnInteraction?.Invoke(type);
        }
    }
}
