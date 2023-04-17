using SweetGame.CodeBase.Abstractions;
using SweetGame.CodeBase.Enum;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Destructor
{
    public class Destructor : MonoBehaviour
    {
        void Start()
        {
            Init();
        }

        // Update is called once per frame

        private void OnTriggerEnter2D(Collider2D collision)
        { 
            {
                if(collision.TryGetComponent<EnemyView>(out EnemyView enemyView))
                {
                    enemyView.Interaction(InteractionType.Deadly);
                }
            }
        }


        private void Init()
        {
            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            Camera camera = Camera.main;

            float height = 2f * camera.orthographicSize;
            float width = height * camera.aspect;

            boxCollider2D.size = new Vector2(0.1f, height);
            gameObject.transform.position = new Vector3(-width, 0);
        }
    }
}
