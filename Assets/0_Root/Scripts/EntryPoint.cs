using SweetGame.Abstractions;
using SweetGame.Animations;
using SweetGame.Game.Spawner;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Background;
using UnityEngine;

namespace SweetGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private AssetsContext assetsContext;
        [SerializeField] private Transform placeForUI;

        [SerializeField] private GameContext _gameContext;
        private MainController mainController;

        public bool IsInit { get; set; }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            if (IsInit)
            {
                return;
            }

            if (_gameContext == null)
            {
                _gameContext = gameObject.GetComponent<GameContext>();
            }

            mainController = new MainController(_gameContext, assetsContext, placeForUI);
            _gameContext.State.Value = StateGame.Menu;

            IsInit = true;
        }

        
    }
}
