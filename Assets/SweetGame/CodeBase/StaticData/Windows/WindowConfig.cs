using System;
using SweetGame.CodeBase.UI.Services.WindowsService;
using SweetGame.CodeBase.UI.Windows;

namespace SweetGame.CodeBase.StaticData.Windows
{
    [Serializable]
    public class WindowConfig
    {
        public WindowID WindowID;
        public WindowBase Prefab;
    }
}