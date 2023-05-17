using System;
using System.Collections.Generic;
using SweetGame.CodeBase.Game.Enemy;

namespace SweetGame.CodeBase.Game.Spawner
{
    public interface ISpawnPoint
    { 
        event Action UpdateCount;
        public IReadOnlyList<EnemyDeath> EnemyDeaths { get; }
        void Spawn();
    }
}