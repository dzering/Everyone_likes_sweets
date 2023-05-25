using System;
using System.Collections.Generic;
using SweetGame.CodeBase.Infrastructure.Factory;
using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Infrastructure.Services.SaveLoad;
using SweetGame.CodeBase.Logic;
using SweetGame.CodeBase.StaticData;
using SweetGame.CodeBase.UI.Services.Factory;
using SweetGame.CodeBase.UI.Services.WindowsService;

namespace SweetGame.CodeBase.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _state;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain, AllServices services)
        {
            _state = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingCurtain, 
                    services.Single<IGameFactory>(), 
                    services.Single<IProgressService>(), 
                    services.Single<IStaticDataService>(), 
                    services.Single<IWindowsService>(),
                    services.Single<IUIFactory>()),
                
                [typeof(GameLoopState)] = new GameLoopState(this),
                [typeof(LoadProgressState)] = new LoadProgressState(
                    this, 
                    services.Single<IProgressService>(), 
                    services.Single<ISaveLoadService>(),
                    services.Single<ISaveTrigger>()),
                [typeof(LoadMenuState)] = new LoadMenuState(this, sceneLoader, 
                    services.Single<IGameFactory>(),
                    services.Single<IUIFactory>(),
                    services.Single<IWindowsService>()),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payLoad) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _state[typeof(TState)] as TState;
    }
}