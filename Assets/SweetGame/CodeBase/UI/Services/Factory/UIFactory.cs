using System;
using SweetGame.CodeBase.Infrastructure.AssetMenegment;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.StaticData;
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


        public UIFactory(IAssets asset, IStaticDataService dataService, IProgressService progressService)
        {
            _asset = asset;
            _dataService = dataService;
            _progressService = progressService;
        }

        public void CreateShop()
        {
            WindowConfig config = _dataService.ForWindows(WindowID.Shop);
            WindowBase windowBase = Object.Instantiate(config.Prefab, _uiRoot);
            windowBase.Construct(_progressService);
        }

        public void CreateUIRoot() => 
            _uiRoot ??= _asset.Instantiate(WINDOWS_UI_ROOT_PATH).transform;
    }
}