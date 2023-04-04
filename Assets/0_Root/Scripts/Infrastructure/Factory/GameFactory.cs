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
        public GameObject CreateMainGame() => _assets.Instantiate(AssetPath.MAIN_GAME_PATH);
    }
}