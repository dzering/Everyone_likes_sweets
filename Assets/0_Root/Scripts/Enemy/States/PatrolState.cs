using SweetGame.Abstractions;
using UnityEngine;

namespace SweetGame.Enemy.States
{
    public class PatrolState : StateBase
    {
        public PatrolState(EnemyBase enemy) : base(enemy) { }
        public override void Move()
        {
            Debug.Log($"Enemy {_enemy.GetType()} is pattroling"); 
        }
    }
}
