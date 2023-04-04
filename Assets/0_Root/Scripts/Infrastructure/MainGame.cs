using System;
using SweetGame.Abstractions;
using SweetGame.Animations;
using SweetGame.Game.Spawn;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Background;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame
{
    internal class MainGame : MonoBehaviour
    {
        [SerializeField] private AssetsContext assetsContext;
        [SerializeField] private Transform placeForUI;

        [SerializeField] private GameContext _context;
        private MainController _mainController;

        private void Awake()
        {
            var pref = Object.Instantiate(placeForUI);
            _context = gameObject.GetComponent<GameContext>();
            _mainController = new MainController(_context, assetsContext, placeForUI);

            _context.State.Value = StateGame.Menu;
        }

        private void Start()
        {
            DontDestroyOnLoad(this);
        }
        
    }
}
