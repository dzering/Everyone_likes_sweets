using UnityEngine;
using SweetGame.Abstractions;

namespace SweetGame.Enemy
{
    internal abstract class EnemyBase : InteractiveObject, IMove
    {
        public abstract void Move();
        public override void Execute()
        {
            base.Execute();
            Move();
        }
    }
}