using SweetGame.CodeBase.Abstractions;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy.States
{
    public sealed class AttackState : StateBase
    {
        private Vector3 _attackDirection;
        private float _speedMultiplier = 1.5f;
        public AttackState(EnemyBase enemy) : base(enemy)
        {
            Debug.Log($"Attack state is activated {_enemy.GetType()}");
            _attackDirection = DirectionCalculate(_enemy.EnemiAI.Player.position).normalized;
        }

        public override void Move(float speed)
        {
            _enemy.Position += _attackDirection * speed * _speedMultiplier * Time.deltaTime;
        }

        private Vector3 DirectionCalculate(Vector3 target)
        {
            return target - _enemy.Position;
        }
    }
}
