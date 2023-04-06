using SweetGame.Game.Sweets;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SweetGame
{
    public class Player : MonoBehaviour, ISavedProgress
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
            {
                _velocity = _jumpForce;
            }

            _velocity += _gravity * Time.deltaTime;
            transform.Translate(new Vector3(0, _velocity * Time.deltaTime, 0));
        }


        public void LoadProgress(PlayerProgress playerProgress)
        {
            if (CurrentLevel() == playerProgress.WordData.PositionOnLevel.Level)
            {
                Vector3Data savedPosition = playerProgress.WordData.PositionOnLevel.Position;
                if (savedPosition != null)
                    Warp(to: savedPosition);
            }
        }

        private void Warp(Vector3Data to)
        {
            transform.position = to.AsUnityVector();
        }

        public void UpdateProgress(PlayerProgress playerProgress) =>
            playerProgress.WordData.PositionOnLevel =
                new PositionOnLevel(
                    CurrentLevel(), transform.position.AsVectorData());

        private static string CurrentLevel()
        {
            return SceneManager.GetActiveScene().name;
        }
    }
}