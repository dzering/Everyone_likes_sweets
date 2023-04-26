using SweetGame.CodeBase.Infrastructure.Services;

namespace SweetGame.CodeBase.UI.Services.Factory
{
    public interface IUIFactory : IService
    {
        void CreateShop();
        void CreateUIRoot();
    }
}