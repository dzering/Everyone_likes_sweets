using UnityEngine;
using UnityEngine.UI;

namespace SweetGame.CodeBase.UI.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public Button Exit;

        private void Awake() => 
            OnAwake();

        private void OnAwake() => 
            Exit.onClick.AddListener(ExitGame);

        private void ExitGame() =>
            Application.Quit();

        private void OnDestroy() => 
            Exit.onClick.RemoveAllListeners();
    }
}