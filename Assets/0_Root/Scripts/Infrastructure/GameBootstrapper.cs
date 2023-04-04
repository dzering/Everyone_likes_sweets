using SweetGame;
using UnityEngine;

public sealed class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private LoadingCurtain _curtain;
    private Game _game;
    private void Awake()
    {
        _game = new Game(this, _curtain);
        _game.GameStateMachine.Enter<BootstrapState>();
        
        DontDestroyOnLoad(this);
    }
}