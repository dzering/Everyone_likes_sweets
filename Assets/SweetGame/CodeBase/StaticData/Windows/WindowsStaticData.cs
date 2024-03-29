using System.Collections.Generic;
using UnityEngine;

namespace SweetGame.CodeBase.StaticData.Windows
{
    [CreateAssetMenu(menuName = "StaticData/Windows", fileName = nameof(WindowsStaticData))]
    public class WindowsStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}