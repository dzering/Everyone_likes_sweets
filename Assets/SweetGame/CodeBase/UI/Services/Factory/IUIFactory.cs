using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.UI.Services.WindowsService;
using UnityEngine;

namespace SweetGame.CodeBase.UI.Services.Factory
{
    public interface IUIFactory : IService
    {
        void CreateShop();
        void CreateUIRoot();
    }
}