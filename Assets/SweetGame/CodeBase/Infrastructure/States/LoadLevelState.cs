using SweetGame.CodeBase.Game.Player;
using SweetGame.CodeBase.Game.Spawner;
using SweetGame.CodeBase.Infrastructure.Factory;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Logic;
using SweetGame.CodeBase.UI;
using UnityEngine;

namespace SweetGame.CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private const string SPAWNER = "Spawner";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _persistentProgressService;

        public LoadLevelState(GameStateMachine stateMachine, 
            SceneLoader sceneLoader, 
            LoadingCurtain loadingCurtain, 
            IGameFactory gameFactory, IPersistentProgressService persistentProgressService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _persistentProgressService = persistentProgressService;
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
                progressReader.LoadProgress(_persistentProgressService.PlayerProgress);
                
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
            foreach (GameObject spawnerObject in GameObject.FindGameObjectsWithTag(SPAWNER))
            {
                EnemySpawner spawner = spawnerObject.GetComponent<EnemySpawner>();
                _gameFactory.Register(spawner);
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