using UnityEngine;

namespace SweetGame
{
    internal class Bird : MonoBehaviour
    {
        [SerializeField] private float speedRelativ;
        private float speed;

        public void Init(float speed)
        {
            this.speed = speed;
        }

        private void Update()
        {
            Move(speed);
        }
        public void Move(float speed)
        {
            transform.position += Vector3.left * speed * speedRelativ * Time.deltaTime;
        }
    }
}
