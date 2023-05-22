using SweetGame.CodeBase.Infrastructure.AssetManagement;
using SweetGame.CodeBase.Infrastructure.Services.Ads;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.StaticData;
using SweetGame.CodeBase.StaticData.Windows;
using SweetGame.CodeBase.UI.Services.WindowsService;
using SweetGame.CodeBase.UI.Windows;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame.CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string WINDOWS_UI_ROOT_PATH = "UI/Windows/WindowsUIRoot";
        private readonly IAssets _asset;
        private readonly IStaticDataService _dataService;
        private Transform _uiRoot;
        private readonly IProgressService _progressService;
        private IAdService _adService;
        private readonly IMenuService _menuService;


        public UIFactory(IAssets asset, IStaticDataService dataService, IProgressService progressService,
            IAdService adService, IMenuService menuService)
        {
            _asset = asset;
            _dataService = dataService;
            _progressService = progressService;
            _adService = adService;
            _menuService = menuService;
        }

        public void CreateShop()
        {
            WindowConfig config = _dataService.ForWindows(WindowID.Shop);
            ShopWindow windowBase = Object.Instantiate(config.Prefab, _uiRoot) as ShopWindow;
            windowBase.Construct(_adService, _progressService);
        }

        public GameObject CreateMainMenu()
        {
            GameObject obj = _asset.Instantiate(AssetPath.MAIN_MENU_PATH, _uiRoot, true);
            MainMenu mainMenu = obj.GetComponent<MainMenu>();
            mainMenu.Construct(_menuService);
            return obj;
        }

        public void CreateUIRoot() => 
            _uiRoot ??= _asset.Instantiate(WINDOWS_UI_ROOT_PATH).transform;
    }
}