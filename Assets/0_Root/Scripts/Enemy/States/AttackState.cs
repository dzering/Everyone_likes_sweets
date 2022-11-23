using SweetGame.Abstractions;
using UnityEngine;
using SweetGame.Game.Sweets;

namespace SweetGame.Enemy.States
{
    public sealed class AttackState : StateBase
    {
        public AttackState(EnemyBase enemy) : base(enemy)
        {
            Debug.Log($"Attack state is activated {_enemy.GetType()}");
        }

        public override void Move(float speed)
        {
            _enemy.Position += Vector3.left * speed * Time.deltaTime;

            Debug.Log($"Enemy {_enemy.GetType()} is attacking");
        }
    }
}
