using System;
using SweetGame.Animations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.Enemy
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