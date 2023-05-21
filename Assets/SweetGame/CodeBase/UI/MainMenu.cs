using System;
using SweetGame.CodeBase.Infrastructure.Services;
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
            Start.onClick.AddListener(_menuService.StarGame);
            Exit.onClick.AddListener(Application.Quit);
        }

        private void OnDestroy()
        {
            Start.onClick.RemoveAllListeners();
            Exit.onClick.RemoveAllListeners();
        }
    }

    public interface IMenuService : IService
    {
        void StarGame();
    }
}