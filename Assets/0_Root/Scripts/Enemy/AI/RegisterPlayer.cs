using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.Enemy
{
    public class RegisterPlayer : MonoBehaviour, IPlayerTransform
    {
        private IGameFactory _gameFactory;
        public Transform PlayerTransform { get; private set; }

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
            PlayerTransform = _gameFactory.Player.transform;
        }
    }
}