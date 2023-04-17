using System;
using System.Collections.Generic;
using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace SweetGame.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject Player { get; }
        event Action PlayerCreated;
        GameObject CreatePlayer();
        GameObject CreateHUD();
        List<ISavedProgress> ProgressWriter { get; }
        List<ISavedProgressReader> ProgressReaders { get; }
        void CleanUp();
    }
}