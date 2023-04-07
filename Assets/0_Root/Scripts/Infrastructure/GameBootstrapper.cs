using SweetGame;
using UnityEngine;
using UnityEngine.Serialization;

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
}