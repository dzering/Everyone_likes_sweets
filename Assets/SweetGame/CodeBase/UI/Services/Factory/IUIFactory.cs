using System.Threading.Tasks;
using SweetGame.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace SweetGame.CodeBase.UI.Services.Factory
{
    public interface IUIFactory : IService
    {
        void CreateShop();
        Task CreateUIRoot();
        Task<GameObject> CreateMainMenu();
        void CreateSettings();
    }
}