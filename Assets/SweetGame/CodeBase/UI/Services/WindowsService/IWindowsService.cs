using SweetGame.CodeBase.Infrastructure.Services;

namespace SweetGame.CodeBase.UI.Services.WindowsService
{
    public interface IWindowsService : IService
    {
        void OpenWindow(WindowID windowID);
    }
}