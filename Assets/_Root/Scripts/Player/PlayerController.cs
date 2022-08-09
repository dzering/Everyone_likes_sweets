using SweetGame.Tools.Resource;
using SweetGame.Abstractions;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;
using JoostenProductions;

namespace SweetGame.Player
{
    internal class PlayerController : BaseController
    {
        public UnityAction OnDead;
        private readonly ResourcePath path = new ResourcePath("Prefabs/Player/Player");

        private PlayerView playerView;

        private float gravity;
        private float jumpForce;

        private float velocity;

        public PlayerController()
        {
            velocity = 0;
            playerView = LoadView();
            playerView.Init(Death);
            gravity = playerView.Gravity;
            jumpForce = playerView.JumpForce;
            JoostenProductions.UpdateManager.SubscribeToUpdate(Update);
        }
        private PlayerView LoadView()
        {
            GameObject pref = ResourceLoader.LoadGameObject(path);
            GameObject go = Object.Instantiate(pref);
            return go.GetComponent<PlayerView>();
        }
        private void Death()
        {
            Debug.Log("Player was dead.");
            OnDead?.Invoke();
        }

        private void Update()
        {

            if (Input.GetKey(KeyCode.Space))
                velocity = jumpForce;

            velocity += gravity * Time.deltaTime;
            playerView.transform.Translate(new Vector3(0, velocity * Time.deltaTime, 0));
        }

        protected override void OnDispose()
        {
            JoostenProductions.UpdateManager.UnsubscribeFromUpdate(Update);
        }


    }
}