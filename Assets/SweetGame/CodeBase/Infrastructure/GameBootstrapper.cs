using SweetGame.CodeBase.Infrastructure.States;
using SweetGame.CodeBase.Logic;
using UnityEngine;

namespace SweetGame.CodeBase.Infrastructure
{
    public sealed class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _curtainPref;
        private Game _game;
        private void Awake()
        {
            _game = new Game(this, Instantiate(_curtainPref));
            _game.GameStateMachine.Enter<BootstrapState>();
        
            DontDestroyOnLoad(this);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}