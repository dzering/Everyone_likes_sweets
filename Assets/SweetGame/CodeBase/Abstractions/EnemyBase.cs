using System;
using UnityEngine;

namespace SweetGame.CodeBase.Abstractions
{
    public abstract class EnemyBase : InteractiveObject, IMove
    {
        public Action<EnemyBase> OnDied;
        public EnemiAI EnemiAI { get; protected set; }
        public abstract Vector3 Position { get; set; }
        public abstract float Speed { get;}
        public abstract void SetPosition(Vector3 position);
        public abstract void ChangeState(StateBase state);
        public abstract void Move();
        public override void Execute()
        {
            Move();
        }
    }
}