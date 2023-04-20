using System;
using System.Collections.Generic;
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
        void Register(ISavedProgressReader progressReader);
        GameObject CrateLoot();
    }
}