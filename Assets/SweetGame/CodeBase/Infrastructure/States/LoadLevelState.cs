using SweetGame.CodeBase.Game.Player;
using SweetGame.CodeBase.Infrastructure.Factory;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Logic;
using SweetGame.CodeBase.StaticData;
using SweetGame.CodeBase.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SweetGame.CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private const string SPAWNER = "Spawner";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IProgressService _progressService;
        private readonly IStaticDataService _staticDataService;

        public LoadLevelState(GameStateMachine stateMachine, 
            SceneLoader sceneLoader, 
            LoadingCurtain loadingCurtain, 
            IGameFactory gameFactory, IProgressService progressService, IStaticDataService staticDataService)
        {
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
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (var progressReader in _gameFactory.ProgressReaders)
            {
                progressReader.LoadProgress(_progressService.PlayerProgress);
                
            }
        }

        private void InitGameWorld()
        {
            InitSpawners();
            GameObject player = _gameFactory.CreatePlayer();
            InitialHud(player);
        }

        private void InitSpawners()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelStaticData = _staticDataService.ForLevel(sceneKey);

            foreach (var spawnerData in levelStaticData.EnemySpawnersData)
            {
                _gameFactory.CreateSpawner(spawnerData.SpawnerId, spawnerData.EnemyTypeId, spawnerData.Position);
            }
        }

        private void InitialHud(GameObject player)
        {
            GameObject hud = _gameFactory.CreateHUD();
            hud.GetComponentInChildren<ActorUI>().Construct(player.GetComponentInChildren<PlayerHealth>());
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }
    }
}