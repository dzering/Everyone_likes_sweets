using System;
using SweetGame.Game;
using UnityEngine;

namespace SweetGame
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        public BootstrapState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            MainController.InputService = RegisterInputService();
        }
        
        public void Exit()
        {
            throw new NotImplementedException();
        }

        public static InputService RegisterInputService()
        {
            if (Application.isEditor)
                return new InputServiceMobile();
            else
                return new InputServiceMobile();
        }
    }
}