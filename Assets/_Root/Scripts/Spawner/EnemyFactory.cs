using SweetGame.Abstractions;
using SweetGame.Enemy;
using SweetGame.Enemy.Bird;
using UnityEngine;
using SweetGame.Utils.AssetsInjector;

namespace SweetGame.Spawner
{
    internal class EnemyFactory
    {
        private readonly ProfileGame profile;
        [InjectAsset("Child")] private GameObject child;

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
                    GameObject childGO = GameObject.Instantiate(child);
                    IEnemy childEnemy = childGO.GetComponent<Child>();

                    return childEnemy;
            }

            return new NullEnemy();
        }
    }
}
