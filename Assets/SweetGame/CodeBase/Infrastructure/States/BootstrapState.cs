using System.Threading.Tasks;
using SweetGame.CodeBase.Audio;
using SweetGame.CodeBase.Infrastructure.AssetManagement;
using SweetGame.CodeBase.Infrastructure.Factory;
using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.Infrastructure.Services.Ads;
using SweetGame.CodeBase.Infrastructure.Services.Input;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Infrastructure.Services.SaveLoad;
using SweetGame.CodeBase.StaticData;
using SweetGame.CodeBase.UI.Services.Factory;
using SweetGame.CodeBase.UI.Services.WindowsService;
using UnityEngine;

namespace SweetGame.CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string INITIAL = "Initial";
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

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            IRandomService randomService = new UnityRandomService();
            RegisterStaticDataService();
            RegisterAdService();

            _services.RegisterSingle<IInputService>(InputService());
            RegisterAssetProvider();
            _services.RegisterSingle<IProgressService>(new ProgressService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(
                _services.Single<IAssets>(),
                _services.Single<IStaticDataService>(),
                randomService, _services.Single<IProgressService>(),
                _gameStateMachine));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(
                _services.Single<IProgressService>(), 
                _services.Single<IGameFactory>()));
            RegisterAudioService(_services.Single<IGameFactory>());
            _services.RegisterSingle<ISaveTrigger>(new SaveTrigger(
                _services.Single<ISaveLoadService>()));
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.Single<IAssets>(),
                _services.Single<IStaticDataService>(),
                _services.Single<IProgressService>(),
                _services.Single<IAdService>(),
                _services.Single<AudioService>().AudioManager,
                _services.Single<ISaveLoadService>()));


            _services.RegisterSingle<IWindowsService>(new WindowsService(_services.Single<IUIFactory>()));
        }

        private void RegisterAudioService(IGameFactory gameFactory)
        {
            IAudioManager audioManager = gameFactory.CreateAudioManager();
            _services.RegisterSingle<AudioService>(new AudioService(audioManager));
        }

        private void RegisterAssetProvider()
        {
            AssetsProvider assetsProvider = new AssetsProvider();
            _services.RegisterSingle<IAssets>(assetsProvider);
            assetsProvider.Initialize();
        }

        private void EnterLoadLevel() => 
            _gameStateMachine.Enter<LoadProgressState>();

        private void RegisterAdService()
        {
            IAdService adService = new AdService();
            adService.Initialize();
            _services.RegisterSingle<IAdService>(adService);
        }

        private void RegisterStaticDataService()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.LoadEnemies();
            staticDataService.LoadSpawners();
            staticDataService.LoadWindows();
            _services.RegisterSingle<IStaticDataService>(staticDataService);
        }

        private static InputService InputService()
        {
            if (Application.isEditor)
                return new InputServiceMobile();
            else
                return new InputServiceMobile();
        }
    }
}