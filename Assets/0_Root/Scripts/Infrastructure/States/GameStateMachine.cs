using System;
using System.Collections.Generic;
using SweetGame.Services.PersistentProgress;

namespace SweetGame
{
    public class GameStateMachine
    {
        private Dictionary<Type, IExitableState> _state;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain, AllServices services)
        {
            _state = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingCurtain, services.Single<IGameFactory>(), services.Single<IPersistentProgressService>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
                [typeof(LoadProgressState)] = new LoadProgressState(
                    this, 
                    services.Single<IPersistentProgressService>(), 
                    services.Single<ISaveLoadService>()),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        public void Enter<TState, TPayload>(TPayload payLoad) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _state[typeof(TState)] as TState;
    }
}