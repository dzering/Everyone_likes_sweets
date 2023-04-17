using SweetGame.CodeBase.Data;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Infrastructure.Services.SaveLoad;

namespace SweetGame.CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrNotNew();
            _gameStateMachine.Enter<LoadLevelState, string>(_progressService.PlayerProgress.WordData.PositionOnLevel.Level);
        }

        public void Exit()
        {
           
        }

        private void LoadProgressOrNotNew()
        {
            _progressService.PlayerProgress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            var playerProgress = new PlayerProgress("Main");
            
            playerProgress.Health.MaxHealth = 50;
            playerProgress.Health.ResetHealth();
            
            return playerProgress;
        }
    }
}