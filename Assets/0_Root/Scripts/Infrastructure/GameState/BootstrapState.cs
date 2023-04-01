using System;
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
            _gameStateMachine.Enter<LoadLevelState>();
        }

        private void RegisterServices()
        {
            MainController.InputService = RegisterInputService();
        }
        
        public void Exit()
        {
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