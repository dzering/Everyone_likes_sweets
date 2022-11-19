using SweetGame.Abstractions;
using SweetGame.Animations;
using SweetGame.Game.Spawn;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Background;
using UnityEngine;

namespace SweetGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private AssetsContext assetsContext;
        [SerializeField] private Transform placeForUI;

        [SerializeField] private GameContext _context;
        private MainController _mainController;

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

            if (_context == null)
            {
                _context = gameObject.GetComponent<GameContext>();
            }

            _mainController = new MainController(_context, assetsContext, placeForUI);
            _context.State.Value = StateGame.Menu;

            IsInit = true;
        }

        
    }
}
