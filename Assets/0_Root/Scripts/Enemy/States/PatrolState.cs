using SweetGame.Abstractions;
using UnityEngine;

namespace SweetGame.Enemy.States
{
    public class PatrolState : StateBase
    {
        private float _time;
        private float _amplitude=0.03f;
        private float _speedYscale = 5;
        public PatrolState(EnemyBase enemy) : base(enemy) 
        {
            Debug.Log($"Patrol state is activated {_enemy.GetType()}");
        }
        public override void Move(float speed)
        {
            _time += Time.deltaTime;
            _enemy.Position += Vector3.left * speed * Time.deltaTime;

            float y = Mathf.Cos(_time * speed * _speedYscale / Mathf.PI) * _amplitude;

            _enemy.Position = new Vector3(_enemy.Position.x, _enemy.Position.y + y, 0);

        }
    }
}
