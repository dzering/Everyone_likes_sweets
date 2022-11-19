using SweetGame.Abstractions;
using SweetGame.Data.Spawner;
using SweetGame.Enemy;
using System.Collections.Generic;
using Random = System.Random;


namespace SweetGame.Game.Spawn
{
    public sealed class Spawner
    {
        private SpawnPointsConfig _spawnPointsConfig;
        private EnemyCreator _enemyCreator;
        private List<EnemyBase> _enemies;
        private GameContext _context;

        public int Count { get => _enemies.Count; }

        public Spawner(GameContext context)
        {
            _context = context;
            _spawnPointsConfig = _context.SpawnPointsConfig;
            _enemies = _context.Enemies;
        }

        public void CreateEnemy(EnemyCreator enemyCreator)
        {
            _enemyCreator = enemyCreator;
            var enemy = enemyCreator.CreateEnemy(_context.GameSpeed);
            _enemies.Add(enemy);
            SetEnemyPosition(enemy);
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
    }
}
