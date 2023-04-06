using System;
using SweetGame.Abstractions;
using SweetGame.Animations;
using SweetGame.Game.Spawn;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Background;
using SweetGame.Game;
using SweetGame.Game.Sweets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame
{
    internal class MainGame : MonoBehaviour
    {
        [SerializeField] private AssetsContext assetsContext;
        [SerializeField] private Transform placeForUI;

        [SerializeField] private GameContext _context;

        private GameController _gameController;
        private CakeController _player;

        private void Awake()
        {
            var pref = Object.Instantiate(placeForUI);
            _context = gameObject.GetComponent<GameContext>();
            //_player = new PlayerFactory().CreatePlayer();
            _gameController = new GameController(_context, assetsContext, placeForUI, _player);
        }

        private void Start()
        {
            DontDestroyOnLoad(this);
        }
        
    }
}
