using SweetGame.Abstractions;
using UnityEngine;

namespace SweetGame.Enemy
{
    internal class NullEnemy : EnemyBase
    {
        public override Vector3 Position { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override float Speed => throw new System.NotImplementedException();

        public override void ChangeState(StateBase state)
        {
            throw new System.NotImplementedException();
        }

        public override void Interaction()
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
