using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _gravity = -9.81f;
        [SerializeField] private float _jumpForce = 10f;
        
        private IInputService _inputService;
        
        private float _velocity;
        public void Awake()
        {
            _velocity = 0;
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Update()
        {
            if (_inputService.IsJumpButtonDown) 
                _velocity = _jumpForce;

            _velocity += _gravity * Time.deltaTime;
            transform.Translate(new Vector3(0, _velocity * Time.deltaTime, 0));
        }
    }
}