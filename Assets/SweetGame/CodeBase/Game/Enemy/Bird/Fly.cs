using System;
using SweetGame.CodeBase.Animators;
using UnityEngine;
using static System.Enum;
using Random = UnityEngine.Random;

namespace SweetGame.CodeBase.Game.Enemy.Bird
{
    public class Fly : MonoBehaviour
    {
        public SpriteAnimatorBase _spriteAnimatorBase;
        public SpriteRenderer SpriteRenderer;
        public float Speed;
        private AnimationTrack _track;

        private void Awake() => 
            GetRandom();

        private void GetRandom()
         {
            Array values = GetValues(typeof(AnimationTrack));
            int i = Random.Range(0, values.Length);
            _track = (AnimationTrack)values.GetValue(i);
        }

        private void Start() => 
            _spriteAnimatorBase.StartAnimation(SpriteRenderer, _track, true, 10);

        private void Update() => 
            transform.Translate(Vector3.left * Time.deltaTime * Speed);

        private void OnDisable() => 
            _spriteAnimatorBase.StopAnimation(SpriteRenderer);
    }
}