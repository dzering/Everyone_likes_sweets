using UnityEngine;

namespace SweetGame.Background
{
    internal class Background : MonoBehaviour
    {
        [SerializeField] private float relativeSpeed = 1;

        private float widthCam;
        private Vector3 startPos;

        private void Start()
        {
            widthCam = Screen.width;
            startPos = transform.position;

            Debug.Log(widthCam);
        }

        private void Update()
        {
            Move(2);
        }
        public void Move(float speed)
        {
            if (transform.position.x > widthCam / 100 || transform.position.x < -widthCam / 100)
                transform.position = startPos;

            transform.position += Vector3.right * - speed * relativeSpeed * Time.deltaTime;
        }
    }
}