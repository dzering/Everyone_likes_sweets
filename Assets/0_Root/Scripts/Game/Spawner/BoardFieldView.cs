using SweetGame.Abstractions.Base;
using SweetGame.Enemy;
using UnityEngine;

namespace SweetGame.Game.Spawner
{
    internal sealed class BoardFieldView : MonoBehaviour
    {
        private Transform[] points;

        public void Init(Transform[] points)
        {
            this.points = points;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out EnemyBase enemy))
            {
                if (enemy is Child)
                {
                    enemy.transform.position = points[2].position;
                    return;
                }
                if (enemy is Bird)
                {
                    enemy.transform.position = points[1].position;
                    return;
                }
            }
        }
    }
}
