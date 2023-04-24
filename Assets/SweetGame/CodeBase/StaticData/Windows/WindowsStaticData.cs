using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Windows", fileName = nameof(WindowsStaticData))]
    public class WindowsStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}