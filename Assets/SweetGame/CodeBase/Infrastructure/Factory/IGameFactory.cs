using System.Collections.Generic;
using System.Threading.Tasks;
using SweetGame.CodeBase.Audio;
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
        Task<GameObject> CreateHUD();
        List<ISavedProgress> ProgressWriter { get; }
        List<ISavedProgressReader> ProgressReaders { get; }
        void CleanUp();
        Task<GameObject> CreateEnemy(EnemyTypeId enemyTypeId, Transform parent);
        Task<SpawnPoint> CreateSpawnPoint(string spawnerId, EnemyTypeId enemyTypeId, Vector3 position);
        Task<LootPiece> CrateLoot();
        void CreateBackground();
        void CreateDestructor(string destructorId, Vector3 position);
        void CreateSpawner(List<ISpawnPoint> spawnPoints, ICoroutineRunner coroutine);
        IAudioManager CreateAudioManager();
        Task WarmUp();
        Task WarmUpUI();
    }
}