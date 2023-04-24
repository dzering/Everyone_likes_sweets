using System;
using SweetGame.CodeBase.UI.Services.WindowsService;
using SweetGame.CodeBase.UI.Windows;

namespace SweetGame.CodeBase.StaticData
{
    [Serializable]
    public class WindowConfig
    {
        public WindowID WindowID;
        public WindowBase Prefab;
    }
}