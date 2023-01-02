using SweetGame.Tools.Resource;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;
using JoostenProductions;

namespace SweetGame.Game.Sweets
{
    internal class CandyController : PlayerController
    {
        public UnityAction OnDead;
        private readonly ResourcePath path = new ResourcePath("Prefabs/Sweets/Candy");

        private CandyView playerView;

        private float gravity;
        private float jumpForce;

        private float velocity;

        private bool canPressed;

        public CandyController()
        {
            canPressed = true;
            velocity = 0;
            playerView = LoadView();
            playerView.Init(Death);
            gravity = playerView.Gravity;
            jumpForce = playerView.JumpForce;
            UpdateManager.SubscribeToUpdate(Update);
        }
        private CandyView LoadView()
        {
            GameObject pref = ResourceLoader.LoadGameObject(path);
            Sweet = Object.Instantiate(pref);
            AddGameObject(Sweet);
            return Sweet.GetComponent<CandyView>();
        }
        private void Death()
        {
            Debug.Log("Player was dead.");
            OnDead?.Invoke();
        }

        private void Update()
        {

            if (canPressed && Input.GetButtonDown("Space"))
            {
                velocity = jumpForce;
                canPressed = false;
            }
            if (Input.GetButtonUp("Space"))
            {
                canPressed = true;
            }

            velocity += gravity * Time.deltaTime;
            playerView.transform.Translate(new Vector3(0, velocity * Time.deltaTime, 0));
        }

        protected override void OnDispose()
        {
            JoostenProductions.UpdateManager.UnsubscribeFromUpdate(Update);
        }
    }
}
