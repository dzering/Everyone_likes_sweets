using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy.AI
{
    public class RegisterPlayer : MonoBehaviour, IPlayerTransform
    {
        public Transform PlayerTransform { get; private set; }

        public void Construct(Transform playerTransform)
        {
            PlayerTransform = playerTransform;
        }
    }
}