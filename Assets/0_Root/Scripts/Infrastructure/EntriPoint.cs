using System;
using SweetGame.Abstractions;
using SweetGame.Animations;
using SweetGame.Game.Spawn;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Background;
using UnityEngine;

namespace SweetGame
{
    internal class EntriPoint : MonoBehaviour
    {
        [SerializeField] private AssetsContext assetsContext;
        [SerializeField] private Transform placeForUI;

        [SerializeField] private GameContext _context;
        private MainController _mainController;

        private void Awake()
        {
            _context = gameObject.GetComponent<GameContext>();
            _mainController = new MainController(_context, assetsContext, placeForUI);
            _mainController.GameStateMachine.Enter<BootstrapState>();
            
            _context.State.Value = StateGame.Menu;
        }

        private void Start()
        {
            DontDestroyOnLoad(this);
        }
        
    }
}
