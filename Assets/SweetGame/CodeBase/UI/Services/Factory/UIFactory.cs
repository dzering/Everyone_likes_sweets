using System;
using SweetGame.CodeBase.Infrastructure.AssetMenegment;
using SweetGame.CodeBase.StaticData;
using SweetGame.CodeBase.UI.Services.WindowsService;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame.CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string WINDOWS_UI_ROOT_PATH = "UI/Windows/WindowsUIRoot";
        private IAssets _asset;
        private IStaticDataService _dataService;
        private Transform _uiRoot;
        
        
        public UIFactory(IAssets asset, IStaticDataService dataService)
        {
            _asset = asset;
            _dataService = dataService;
        }

        public void CreateShop()
        {
            WindowConfig config = _dataService.ForWindows(WindowID.Shop);
            Object.Instantiate(config.Prefab, _uiRoot);
        }

        public void CreateUIRoot()
        { 
            _uiRoot = _asset.Instantiate(WINDOWS_UI_ROOT_PATH).transform;
        }
    }
}