using SweetGame.Abstractions;
using SweetGame.Data.Spawner;
using SweetGame.Enemy;
using System;
using System.Collections.Generic;
using Random = System.Random;


namespace SweetGame.Game.Spawn
{
    public sealed class Spawner
    {
        private SpawnPointsConfig _spawnPointsConfig;
        private GameContext _context;

        public Spawner(GameContext context)
        {
            _context = context;
            _spawnPointsConfig = _context.SpawnPointsConfig;
        }


        public void CreateEnemy(EnemyCreator enemyCreator)
        {
            var enemy = enemyCreator.CreateEnemy(_context.GameSpeed);
            _context.ExecutiveObjects.AddExecuteObject(enemy);
            SetEnemyPosition(enemy);
            enemy.OnDied += Remove;
        }

        private void SetEnemyPosition(EnemyBase enemy)
        {
            if (enemy is IFly)
            {
                EnemyPosityonByType(enemy, EnemyMovingType.Fly);
            }
            else if(enemy is IGround)
            {
                EnemyPosityonByType(enemy, EnemyMovingType.Groung);
            }
        }

        private void EnemyPosityonByType(EnemyBase enemy, EnemyMovingType type)
        {
            Random random = new Random();
            var points = _spawnPointsConfig.GetStackOfPoints(type);
            var position = points[random.Next(0, points.Count)].position;
            enemy.Position = position;
        }

        private void Remove(EnemyBase enemy)
        {
            if(enemy is IExecute)
            {
                var execute = (IExecute)enemy;
                _context.ExecutiveObjects.RemoveExecuteObject(execute);
                enemy.OnDied -= Remove;
            }
        }
    }
}
