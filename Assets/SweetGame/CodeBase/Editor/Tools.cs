using UnityEditor;
using UnityEngine;

namespace SweetGame.CodeBase.Editor
{
    
    public class Tools
    {
        [MenuItem("Tools/ClearPrefs")]
        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs is cleared");
        }
    }
}