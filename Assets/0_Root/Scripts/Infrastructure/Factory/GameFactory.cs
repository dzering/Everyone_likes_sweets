using System.Collections.Generic;
using SweetGame.Game.Sweets;
using UnityEngine;

namespace SweetGame
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreatePlayer()
        {
            GameObject player = _assets.Instantiate(AssetPath.PLAYER_PATH);

            return player;
        }

        public GameObject CreateHUD() => _assets.Instantiate(AssetPath.HUD_PATH);

        public List<ISavedProgress> ProgressWriter { get; } = new List<ISavedProgress>();

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();

        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriter.Clear();
        }
    }
}