using UnityEngine;

namespace SweetGame.Background
{
    [RequireComponent(typeof(SpriteRenderer))]
    internal class Background : MonoBehaviour
    {
        [SerializeField] private float relativeSpeed = 1;
        private SpriteRenderer spriteRenderer;

        private Vector2 cashPosition;
        private Vector2 size;
                
        private float leftBorder => cashPosition.x - size.x / 2;
        private float rightBorder => cashPosition.x + size.x / 2;
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            size = spriteRenderer.bounds.size;
            cashPosition = transform.position;
        }
        public void Move()
        {
            Vector3 position = transform.position;
            position += -Vector3.right * Time.deltaTime * relativeSpeed;

            if(position.x <= leftBorder) 
                position.x = rightBorder - (leftBorder - position.x);

            if(position.x >= rightBorder)
                position.x = leftBorder + (rightBorder - position.x);

            transform.position = position;
        }
    }
}