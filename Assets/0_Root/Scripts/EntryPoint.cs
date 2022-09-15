using SweetGame.Abstractions;
using SweetGame.Animations;
using SweetGame.Game.Spawner;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Background;
using UnityEngine;

namespace SweetGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private AssetsContext assetsContext;
        [SerializeField] private Transform placeForUI;

        private ProfileGame profileGame;
        private MainController mainController;

        private void Start()
        {
            profileGame = new ProfileGame();
            mainController = new MainController(profileGame, assetsContext, placeForUI);
            profileGame.State.Value = StateGame.Menu;
        }

        
    }
}
