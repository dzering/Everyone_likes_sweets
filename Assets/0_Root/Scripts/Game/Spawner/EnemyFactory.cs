using SweetGame.Enemy;
using SweetGame.Abstractions;
using SweetGame.Utils.AssetsInjector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame.Game.Spawn
{
    internal class EnemyFactory : IEnemyFactory<EnemyBase>
    {
        private readonly GameContext profile;
        [InjectAsset("Child")] private GameObject child;

        public EnemyFactory(GameContext profile)
        {
            this.profile = profile;
        }

        public EnemyBase GetEnemy(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.Bird:
                    GameObject pref = Resources.Load<GameObject>("Prefabs/Enemies/Bird");
                    GameObject obj = Object.Instantiate(pref);

                    return obj.GetComponent<BirdController>();

                case EnemyType.Child:
                    GameObject go = Object.Instantiate(child);
                    return go.GetComponent<EnemyBase>(); 
            }

            return new NullEnemy();
        }
    }
}
