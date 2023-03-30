using System;
using SweetGame.Game;
using UnityEngine;

namespace SweetGame
{
    public class BootstrapState : IState
    {
        private const string INITIAL = "Initial";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoad;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoad)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoad = sceneLoad;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoad.Load(name: INITIAL, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            
        }

        private void RegisterServices()
        {
            MainController.InputService = RegisterInputService();
        }
        
        public void Exit()
        {
            throw new NotImplementedException();
        }

        public static InputService RegisterInputService()
        {
            if (Application.isEditor)
                return new InputServiceMobile();
            else
                return new InputServiceMobile();
        }
    }
}