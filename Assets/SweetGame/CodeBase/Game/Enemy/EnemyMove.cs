using SweetGame.CodeBase.Animators;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.CodeBase.Game.Enemy
{
    public class EnemyMove : Follow
    {
        [SerializeField] private float _speed = 1f;
        [FormerlySerializedAs("_enemyAnimator")] [SerializeField] private EnemyAnimatorBase _enemyAnimatorBase;

        public float Speed { get => _speed; private set => _speed = value; }

        private void Start()
        {
            //_enemyAnimator.PlayRun();
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
            _enemyAnimatorBase.PlayRun();

        private void OnEnable() => 
            _enemyAnimatorBase.PlayRun();
    }
}