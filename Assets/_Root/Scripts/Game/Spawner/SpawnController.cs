using SweetGame.Abstractions.Base;
using SweetGame.Abstractions;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Enemy;
using UnityEngine;

namespace SweetGame.Game.Spawner
{
    internal sealed class SpawnController
    {
        [InjectAsset("SpawnPoints")] private GameObject spawnPoints;
        private Transform[] points;
        public Transform[] Points => points;
        private readonly ListExecutiveObject listExecutive;

        private readonly IEnemyFactory<EnemyBase> enemyFactory;

        public SpawnController(IEnemyFactory<EnemyBase> enemyFactory, ListExecutiveObject listExecutive)
        {
            this.enemyFactory = enemyFactory;
            this.listExecutive = listExecutive;
        }

        public void CreateObject()
        {
            if(spawnPoints != null)
                points = spawnPoints.GetComponentsInChildren<Transform>();

            EnemyBase enemy = enemyFactory.GetEnemy(EnemyType.Child);
            listExecutive.AddExecuteObject(enemy);

            if(enemy is Child & points.Length != 0)
                enemy.transform.position = points[2].position;

            enemy = enemyFactory.GetEnemy(EnemyType.Bird);
            enemy.transform.position = points[1].position;
            listExecutive.AddExecuteObject((EnemyBase)enemy);
        }
    }
}
