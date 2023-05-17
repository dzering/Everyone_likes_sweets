using System.Collections.Generic;
using SweetGame.CodeBase.Game.Enemy;
using SweetGame.CodeBase.Game.Spawner;
using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace SweetGame.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject Player { get; }
        GameObject CreatePlayer();
        GameObject CreateHUD();
        List<ISavedProgress> ProgressWriter { get; }
        List<ISavedProgressReader> ProgressReaders { get; }
        void CleanUp();
        GameObject CreateEnemy(EnemyTypeId enemyTypeId, Transform parent);
        SpawnPoint CreateSpawnPoint(string spawnerId, EnemyTypeId enemyTypeId, Vector3 position);
        LootPiece CrateLoot();
        void CreateBackground();
        void CreateDestructor(string destructorId, Vector3 position);
        void CreateSpawner(List<ISpawnPoint> spawnPoints, ICoroutineRunner coroutine);
    }
}