using SweetGame.CodeBase.Infrastructure.Factory;
using SweetGame.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy.AI
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