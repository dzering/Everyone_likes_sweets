using SweetGame.Abstractions;
using SweetGame.Enemy;
using SweetGame.Enemy.Bird;

namespace SweetGame.Spawner
{
    internal class EnemyFactory
    {
        private readonly ProfileGame profile;

        public EnemyFactory(ProfileGame profile)
        {
            this.profile = profile;
        }

        public IEnemy GetEnemy(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.Bird:
                    IEnemy bird = new Bird(profile.GameSpeed);
                    return bird;
                case EnemyType.Child:
                    IEnemy child = new Child(profile.GameSpeed);
                    return child;
            }
            return new NullEnemy();
        }
    }
}
