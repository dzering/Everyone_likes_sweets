using SweetGame.Tools.Resource;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;
using JoostenProductions;

namespace SweetGame.Game.Sweets
{
    internal class CakeController : PlayerController, ISavedProgress
    {
        public UnityAction OnDead;
        private readonly ResourcePath path = new ResourcePath("Prefabs/Sweets/Cake");
        private IInputService _inputService;
        
        private CakeView playerView;

        private float gravity;
        private float jumpForce;

        private float velocity;

        public CakeController()
        {
            velocity = 0;
            playerView = LoadView();
            playerView.Init(Death);
            gravity = playerView.Gravity;
            jumpForce = playerView.JumpForce;
            UpdateManager.SubscribeToUpdate(Update);
            _inputService = AllServices.Container.Single<IInputService>();
        }
        private CakeView LoadView()
        {
            GameObject pref = ResourceLoader.LoadGameObject(path);
            Sweet = Object.Instantiate(pref);
            AddGameObject(Sweet);
            return Sweet.GetComponent<CakeView>();
        }
        private void Death()
        {
            Debug.Log("Player was dead.");
            OnDead?.Invoke();
        }

        private void Update()
        {
            if (_inputService.IsJumpButtonDown)
            {
                velocity = jumpForce;
            }
            
            velocity += gravity * Time.deltaTime;
            playerView.transform.Translate(new Vector3(0, velocity * Time.deltaTime, 0));
        }

        protected override void OnDispose()
        {
            JoostenProductions.UpdateManager.UnsubscribeFromUpdate(Update);
        }

        public void Interaction()
        {
            Debug.Log("Interactions player with boarder");
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
           
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.WordData.Position = playerView.transform.position.AsVectorData();
        }
    }
}