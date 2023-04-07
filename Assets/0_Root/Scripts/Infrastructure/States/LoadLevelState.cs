using SweetGame.Services.PersistentProgress;
using UnityEngine;

namespace SweetGame
{
    public class LoadLevelState : IPayloadState<string>
    {
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
            _gameFactory.CreatePlayer();
            _gameFactory.CreateHUD();
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }
    }
}