using SweetGame.Tools.Resource;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;
using JoostenProductions;

namespace SweetGame.Game.Sweets
{
    internal class CakeController : PlayerController
    {
        public UnityAction OnDead;
        private readonly ResourcePath path = new ResourcePath("Prefabs/Sweets/Cake");

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

            if (Input.GetButtonDown("Jump"))
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
    }
}