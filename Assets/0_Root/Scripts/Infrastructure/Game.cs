using SweetGame;

public class Game
{
    public readonly GameStateMachine GameStateMachine;
    public static InputService InputService;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
    {
        GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container);
    }
}
