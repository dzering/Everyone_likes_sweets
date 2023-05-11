using SweetGame.CodeBase.Animators;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.CodeBase.Game.Enemy.Bird
{
    public class Fly : MonoBehaviour
    {
        [FormerlySerializedAs("SpriteAnimator")] public SpriteAnimatorBase _spriteAnimatorBase;
        public SpriteRenderer SpriteRenderer;
        public float Speed;

        private void Start()
        {
            _spriteAnimatorBase.StartAnimation(SpriteRenderer, AnimationTrack.Bird_1_fly, true, 10);
           
        }

        private void Update()
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }

        private void OnDisable()
        {
            _spriteAnimatorBase.StopAnimation(SpriteRenderer);
        }
    }
}