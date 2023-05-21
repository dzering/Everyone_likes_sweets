using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Infrastructure.States;

namespace SweetGame.CodeBase.UI
{
    public class MenuService : IMenuService
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IProgressService _progressService;

        public MenuService(GameStateMachine stateMachine, IProgressService progressService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
        }

        public void StarGame()
        {
            _stateMachine.Enter<LoadLevelState, string>(_progressService.PlayerProgress.WordData.PositionOnLevel.Level);
        }
    }
}