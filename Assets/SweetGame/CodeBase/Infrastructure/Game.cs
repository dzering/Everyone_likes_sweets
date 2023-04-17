using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.Infrastructure.Services.Input;
using SweetGame.CodeBase.Infrastructure.States;
using SweetGame.CodeBase.Logic;

namespace SweetGame.CodeBase.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine GameStateMachine;
        public static InputService InputService;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container);
        }
    }
}
