using System;
using System.Collections.Generic;

namespace SweetGame
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _state;
        private IState _activeState;

        public GameStateMachine()
        {
            _state = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this)
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            var state = _state[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}