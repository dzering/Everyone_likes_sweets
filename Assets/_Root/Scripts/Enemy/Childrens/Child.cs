using UnityEngine;
using SweetGame.Abstractions;

namespace SweetGame.Enemy
{
    internal class Child : EnemyBase
    {
        private float speedRelative = 1.5f;
        private float speed = 2;
        public override void Move()
        {
            transform.position += Vector3.left * speed * speedRelative * Time.deltaTime;
        }

    }
}
