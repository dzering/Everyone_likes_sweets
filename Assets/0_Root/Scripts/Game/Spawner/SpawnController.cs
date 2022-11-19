using SweetGame.Abstractions;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Enemy;
using UnityEngine;

namespace SweetGame.Game.Spawn
{
    internal sealed class SpawnController
    {
        private readonly ListExecutiveObject listExecutive;

        private readonly IEnemyFactory<EnemyBase> enemyFactory;

        public SpawnController(IEnemyFactory<EnemyBase> enemyFactory, ListExecutiveObject listExecutive)
        {
            this.enemyFactory = enemyFactory;
            this.listExecutive = listExecutive;
        }

        public void CreateObject()
        {
            EnemyBase enemy = enemyFactory.GetEnemy(EnemyType.Child);
            listExecutive.AddExecuteObject(enemy);

            //if(enemy is Child & points.Length != 0)
            //    enemy.transform.position = points[2].position;

            //enemy = enemyFactory.GetEnemy(EnemyType.Bird);
            //enemy.transform.position = points[1].position;
            //listExecutive.AddExecuteObject((EnemyBase)enemy);
        }
    }
}
