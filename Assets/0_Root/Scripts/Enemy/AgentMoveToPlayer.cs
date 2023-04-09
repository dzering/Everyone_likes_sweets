using System;
using UnityEngine;

namespace SweetGame.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private Transform _playerTransform;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_gameFactory.Player != null)
                InitializePlayerTransform();
            else
                _gameFactory.PlayerCreated += Initialized;
        }

        private void Initialized()
        {
            InitializePlayerTransform();
        }

        private void InitializePlayerTransform()
        {
            _playerTransform = _gameFactory.Player.transform;
        }
    }
}