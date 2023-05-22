using SweetGame.CodeBase.Infrastructure.Services;

namespace SweetGame.CodeBase.UI
{
    public interface IMenuService : IService
    {
        void ClickButton(ButtonActionID ActionID);
    }
}