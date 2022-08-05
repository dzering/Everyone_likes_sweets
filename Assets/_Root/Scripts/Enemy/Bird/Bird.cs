using UnityEngine;
using SweetGame.Abstractions.Base;

namespace SweetGame.Enemy
{
    internal class Bird : EnemyBase
    {
        [SerializeField] private float speedRelative = -1.5f;
        private float speed = 2f;
        public override void Move()
        {
            transform.position += Vector3.left * speed * speedRelative * Time.deltaTime;
        }

        public override void Interaction()
        {
            base.Interaction();

        }
    }
}
