using System;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Infrastructure.States;
using SweetGame.CodeBase.UI.Services.WindowsService;

namespace SweetGame.CodeBase.UI
{
    public class MenuService : IMenuService
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IProgressService _progressService;
        private readonly IWindowsService _windowsService;

        public MenuService(GameStateMachine stateMachine, IProgressService progressService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
        }

        public void ClickButton(ButtonActionID ActionID)
        {
            switch (ActionID)
            {
                case ButtonActionID.None:
                    break;
                
                case ButtonActionID.StartGame:
                    _stateMachine.Enter<LoadLevelState, string>(_progressService.PlayerProgress.WordData.PositionOnLevel.Level);
                    break;

                case ButtonActionID.OpenSetting:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ActionID), ActionID, null);
            }
        }
    }
}