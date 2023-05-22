using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SweetGame.CodeBase.UI
{
    public class MainMenu : MonoBehaviour
    {
        public Button Start;
        public Button Exit;
        private IMenuService _menuService;

        public void Construct(IMenuService menuService)
        {
            _menuService = menuService;
            Start.onClick.AddListener(StartGame);
            Exit.onClick.AddListener(ExitGame);
        }

        private void StartGame() => 
            _menuService.ClickButton(ButtonActionID.StartGame);

        private void ExitGame() =>
            Application.Quit();

        private void OnDestroy()
        {
            Start.onClick.RemoveAllListeners();
            Exit.onClick.RemoveAllListeners();
        }
    }
}