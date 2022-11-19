using SweetGame.Abstractions;
using UnityEngine;

namespace SweetGame.Enemy
{
    internal class NullEnemy : EnemyBase
    {
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
