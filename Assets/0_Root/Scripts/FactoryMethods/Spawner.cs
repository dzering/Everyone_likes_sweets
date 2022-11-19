using SweetGame.Abstractions;
using SweetGame.Data.Spawner;
using System.Collections.Generic;
using System;

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
            Random random = new Random();
            var points = _spawnPointsConfig.SpawnPoints;
            var enemy = enemyCreator.CreateEnemy(_context.GameSpeed);

            _enemies.Add(enemy);
            enemy.SetPosition(_spawnPointsConfig.SpawnPoints[random.Next(0, points.Length)].position);
        }

    }
}
