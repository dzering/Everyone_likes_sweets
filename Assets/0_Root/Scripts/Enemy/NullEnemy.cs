using SweetGame.Abstractions.Base;

namespace SweetGame.Enemy
{
    internal class NullEnemy : EnemyBase
    {
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
