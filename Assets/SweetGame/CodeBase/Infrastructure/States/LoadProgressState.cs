using SweetGame.CodeBase.Data;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Infrastructure.Services.SaveLoad;

namespace SweetGame.CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly ISaveTrigger _saveTrigger;

        public LoadProgressState(GameStateMachine gameStateMachine, IProgressService progressService, ISaveLoadService saveLoadService, ISaveTrigger saveTrigger)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _saveTrigger = saveTrigger;
        }

        public void Enter()
        {
            LoadProgressOrNotNew();
            _progressService.PlayerProgress.WordData.LootData.ChangeLoot += _saveTrigger.Save;

            _gameStateMachine.Enter<LoadMenuState, string>("Menu");
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