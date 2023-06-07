using System.Threading.Tasks;
using SweetGame.CodeBase.Audio;
using SweetGame.CodeBase.Infrastructure.AssetManagement;
using SweetGame.CodeBase.Infrastructure.Services.Ads;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Infrastructure.Services.SaveLoad;
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
        private IAudioManager _audioManager;
        private readonly ISaveLoadService _saveLoadService;


        public UIFactory(IAssets asset, IStaticDataService dataService, IProgressService progressService,
            IAdService adService, IAudioManager audioManager, ISaveLoadService saveLoadService)
        {
            _asset = asset;
            _dataService = dataService;
            _progressService = progressService;
            _adService = adService;
            _audioManager = audioManager;
            _saveLoadService = saveLoadService;
        }

        public void CreateShop()
        {
            WindowConfig config = _dataService.ForWindows(WindowID.Shop);
            ShopWindow windowBase = Object.Instantiate(config.Prefab, _uiRoot) as ShopWindow;
            windowBase.Construct(_adService, _progressService);
        }

        public void CreatePause()
        {
            WindowConfig config = _dataService.ForWindows(WindowID.Pause);
            PauseWindow pauseWindow = Object.Instantiate(config.Prefab, _uiRoot) as PauseWindow;
        }

        public async Task<GameObject> CreateMainMenu()
        {
            GameObject prefab = await _asset.Load<GameObject>(AssetAddress.MAIN_MENU);
            return Object.Instantiate(prefab, _uiRoot);
        }

        public void CreateSettings()
        {
            WindowConfig config = _dataService.ForWindows(WindowID.Settings);
            SettingsWindow settingsWindow = Object.Instantiate(config.Prefab, _uiRoot) as SettingsWindow;
            settingsWindow.Construct(_progressService, _audioManager, _saveLoadService);

        }

        public async Task CreateUIRoot()
        {
            GameObject uiRoot = await _asset.Load<GameObject>(AssetAddress.UI_ROOT);
            _uiRoot = Object.Instantiate(uiRoot).transform;
        }
    }
}