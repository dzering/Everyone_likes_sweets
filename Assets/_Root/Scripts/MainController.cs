using SweetGame.Abstractions;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Game;
using System;

namespace SweetGame
{
    internal class MainController : BaseController
    {
        private readonly ProfileGame profileGame;
        private readonly AssetsContext assetsContext;

        private GameController gameController;

        public MainController(ProfileGame profileGame, AssetsContext assetsContext)
        {
            this.profileGame = profileGame;
            this.assetsContext = assetsContext;
            profileGame.State.SubscribeOnChange(ChooseGameState);
        }

        protected override void OnDispose()
        {
            DisposeControllers();
            profileGame.State.UnsubscribeOnChange(ChooseGameState);
        }

        private void ChooseGameState(StateGame stateGame)
        {
            DisposeControllers();

            switch (stateGame)
            {
                case StateGame.None:
                    break;
                case StateGame.Menu:
                    break;
                case StateGame.Game:
                    gameController = new GameController(profileGame, assetsContext);
                    AddController(gameController);
                    break;

                default:
                    break;
            }
        }

        private void DisposeControllers()
        {
            gameController?.Dispose();
        }
    }
}