using UnityEngine;
using SweetGame.Abstractions;

namespace SweetGame.Enemy
{
    internal class Child : MonoBehaviour, IEnemy
    {
        private float speed;
        public Child(float speed)
        {
            this.speed = speed;
        }
        public void Move()
        {
            Debug.Log("Child is moving.");
        }
    }
}
