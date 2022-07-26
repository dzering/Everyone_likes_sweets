using SweetGame.Enemy;
using SweetGame.Enemy.Bird;
using SweetGame.Abstractions;
using SweetGame.Utils.AssetsInjector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame.Spawner
{
    internal class EnemyFactory
    {
        private readonly ProfileGame profile;
        [InjectAsset("Child")] private readonly GameObject child;

        public EnemyFactory(ProfileGame profile)
        {
            this.profile = profile;
        }

        public IMove GetEnemy(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.Bird:
                    IMove bird = new Bird(profile.GameSpeed);
                    return bird;

                case EnemyType.Child:
                    GameObject go = Object.Instantiate(child);
                    return go.GetComponent<EnemyBase>(); 
            }

            return new NullEnemy();
        }
    }
}
