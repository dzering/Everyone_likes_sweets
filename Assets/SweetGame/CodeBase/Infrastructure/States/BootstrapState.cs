using SweetGame.CodeBase.Infrastructure.AssetMenegment;
using SweetGame.CodeBase.Infrastructure.Factory;
using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.Infrastructure.Services.Input;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace SweetGame.CodeBase.Infrastructure.States
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
            _gameStateMachine.Enter<LoadProgressState>();
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(InputService());
            _services.RegisterSingle<IAssets>(new AssetsProvider());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IGameFactory>(
                new GameFactory(_services.Single<IAssets>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(
                _services.Single<IPersistentProgressService>(), _services.Single<IGameFactory>()));
            _services.RegisterSingle<ISaveTrigger>(new SaveTrigger(_services.Single<ISaveLoadService>()));
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