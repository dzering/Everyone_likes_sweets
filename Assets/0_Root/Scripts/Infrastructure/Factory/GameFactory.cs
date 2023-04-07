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

        public List<ISavedProgress> ProgressWriter { get; } = new List<ISavedProgress>();
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();

        public GameObject CreatePlayer() => InstantiateRegister(AssetPath.PLAYER_PATH);

        public GameObject CreateHUD() => InstantiateRegister(AssetPath.HUD_PATH);

        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriter.Clear();
        }

        private GameObject InstantiateRegister(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject player)
        {
            foreach (ISavedProgressReader progressReader in player.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                ProgressWriter.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    }
}