using SweetGame.Abstractions;

namespace SweetGame.Enemy
{
    internal class NullEnemy : IEnemy
    {
        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
