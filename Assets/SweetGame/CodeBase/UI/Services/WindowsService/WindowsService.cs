using System;
using SweetGame.CodeBase.UI.Services.Factory;

namespace SweetGame.CodeBase.UI.Services.WindowsService
{
    public class WindowsService : IWindowsService
    {
        private readonly IUIFactory _uiFactory;

        public WindowsService(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void OpenWindow(WindowID windowID)
        {
            switch (windowID)
            {
                case WindowID.None:
                    break;
                case WindowID.Shop:
                    _uiFactory.CreateShop();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(windowID), windowID, null);
            }
        }
    }
}