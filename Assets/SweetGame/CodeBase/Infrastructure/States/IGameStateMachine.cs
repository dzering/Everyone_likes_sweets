namespace SweetGame.CodeBase.Infrastructure.States
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payLoad) where TState : class, IPayloadState<TPayload>;
    }
}