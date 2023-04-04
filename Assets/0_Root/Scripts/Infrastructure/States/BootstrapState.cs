using System;
using UnityEngine;

namespace SweetGame
{
    public class BootstrapState : IState
    {
        private const string INITIAL = "Initial";
        private const string NAME_MAIN_SCENE = "Main";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoad;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoad, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoad = sceneLoad;
            _services = services;
            
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoad.Load(name: INITIAL, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(NAME_MAIN_SCENE);
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(InputService());
            _services.RegisterSingle<IAssets>(new AssetsProvider());
            _services.RegisterSingle<IGameFactory>(
                new GameFactory(_services.Single<IAssets>()));
        }
        
        public void Exit()
        {
        }

        public static InputService InputService()
        {
            if (Application.isEditor)
                return new InputServiceMobile();
            else
                return new InputServiceMobile();
        }
    }
}