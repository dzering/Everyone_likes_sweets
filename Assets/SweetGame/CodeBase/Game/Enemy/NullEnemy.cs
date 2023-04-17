using SweetGame.CodeBase.Abstractions;
using SweetGame.CodeBase.Enum;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    internal class NullEnemy : EnemyBase
    {
        public override Vector3 Position { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override float Speed => throw new System.NotImplementedException();

        public override void ChangeState(StateBase state)
        {
            throw new System.NotImplementedException();
        }

        public override void Interaction(InteractionType type)
        {
            throw new System.NotImplementedException();
        }

        public override void Move()
        {
            throw new System.NotImplementedException();
        }

        public override void SetPosition(Vector3 position)
        {
            throw new System.NotImplementedException();
        }
    }
}
