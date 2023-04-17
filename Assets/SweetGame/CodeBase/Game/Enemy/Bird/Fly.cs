using SweetGame.CodeBase.Animators;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy.Bird
{
    public class Fly : MonoBehaviour
    {
        public SpriteAnimator SpriteAnimator;
        public SpriteRenderer SpriteRenderer;
        public float Speed;

        private void Start()
        {
            SpriteAnimator.StartAnimation(SpriteRenderer, AnimationTrack.Bird_1_fly, true, 10);
           
        }

        private void Update()
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }

        private void OnDisable()
        {
            SpriteAnimator.StopAnimation(SpriteRenderer);
        }
    }
}