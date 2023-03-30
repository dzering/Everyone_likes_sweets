﻿using SweetGame.Abstractions;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Game;
using SweetGame.UI;
using UnityEngine;

namespace SweetGame
{
    internal class MainController : BaseController
    {
        public static InputService InputService;
        public GameStateMachine GameStateMachine;
        
        private readonly GameContext profileGame;
        private readonly AssetsContext assetsContext;
        private readonly Transform placeForUI;

        private GameController gameController;
        private MainMenuController mainMenuController;

        public MainController(GameContext profileGame, AssetsContext assetsContext, Transform placeForUI)
        {
           // GameStateMachine = new GameStateMachine(TODO);
            
            this.placeForUI = placeForUI;
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
                    //mainMenuController = new MainMenuController(profileGame, placeForUI);
                    gameController = new GameController(profileGame, assetsContext, placeForUI);
                    break;
                case StateGame.Game:
                    gameController = new GameController(profileGame, assetsContext, placeForUI);
                    AddController(gameController);
                    break;

                default:
                    break;
            }
        }

        private void DisposeControllers()
        {
            gameController?.Dispose();
            mainMenuController?.Dispose();
        }
    }
}