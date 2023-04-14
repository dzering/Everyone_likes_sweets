using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.Enemy
{
    public class EnemyMove : Follow
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private EnemyAnimator _enemyAnimator;

        public float Speed { get => _speed; private set => _speed = value; }

        private void Start()
        {
            _enemyAnimator.PlayRun();
            Debug.Log("Enemy Start");
        }

        private void Update()
        {
            // if(_enemyAnimator.State != AnimatorState.Run)
            //     return;
            
            Move();
        }

        private void Move() => 
            transform.Translate(Vector3.left * Time.deltaTime * Speed);

        private void OnDisable() => 
            _enemyAnimator.PlayRun();

        private void OnEnable() => 
            _enemyAnimator.PlayRun();
    }
}