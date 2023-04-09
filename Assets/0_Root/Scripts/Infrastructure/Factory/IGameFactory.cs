using System;
using System.Collections.Generic;
using SweetGame.Game;
using SweetGame.Game.Sweets;
using UnityEngine;

namespace SweetGame
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