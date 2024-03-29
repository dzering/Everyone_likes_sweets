using System.Collections.Generic;
using SweetGame.CodeBase.Game.Player;
using SweetGame.CodeBase.Game.Spawner;
using SweetGame.CodeBase.Infrastructure.Factory;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Logic;
using SweetGame.CodeBase.StaticData;
using SweetGame.CodeBase.UI.Elements;
using SweetGame.CodeBase.UI.Services.Factory;
using SweetGame.CodeBase.UI.Services.WindowsService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SweetGame.CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IProgressService _progressService;
        private readonly IStaticDataService _staticDataService;
        private IUIFactory _uiFactory;

        public LoadLevelState(GameStateMachine stateMachine,
            SceneLoader sceneLoader,
            LoadingCurtain loadingCurtain,
            IGameFactory gameFactory, IProgressService progressService, IStaticDataService staticDataService,
            IWindowsService windowService, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _staticDataService = staticDataService;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _gameFactory.CleanUp();
            _gameFactory.WarmUp();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => 
            _loadingCurtain.Hide();

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (var progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.PlayerProgress);
        }

        private void InitGameWorld()
        {
            InitUiRoot(_uiFactory);
            GameObject player = _gameFactory.CreatePlayer();
            InitSpawners();
            InitDestructor();
            InitialHud(player);
            InitBackground();
        }

        private void InitDestructor()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelStaticData = _staticDataService.ForLevel(sceneKey);
            foreach (var destructorData in levelStaticData.DestructorData)
                _gameFactory.CreateDestructor(destructorData.DestructorId, destructorData.Position);
        }

        private void InitBackground() => 
            _gameFactory.CreateBackground();

        private void InitUiRoot(IUIFactory uiFactory) => 
            uiFactory.CreateUIRoot();

        private async void InitSpawners()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelStaticData = _staticDataService.ForLevel(sceneKey);
            List<ISpawnPoint> spawnPoints = new List<ISpawnPoint>();
            
            foreach (var spawnerData in levelStaticData.EnemySpawnersData)
            {
                SpawnPoint spawnPoint = await _gameFactory.CreateSpawnPoint(spawnerData.SpawnerId, spawnerData.EnemyTypeId, spawnerData.Position);
                spawnPoints.Add(spawnPoint);
            }
            
            _gameFactory.CreateSpawner(spawnPoints, _sceneLoader.CoroutineRunner);
        }

        private async void InitialHud(GameObject player)
        {
            GameObject hud = await _gameFactory.CreateHUD();
            hud.GetComponentInChildren<ActorUI>().Construct(player.GetComponentInChildren<PlayerHealth>());
        }
    }
}