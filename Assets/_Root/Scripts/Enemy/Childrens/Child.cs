using UnityEngine;
using SweetGame.Abstractions.Base;

namespace SweetGame.Enemy
{
    internal class Child : EnemyBase
    {
        [SerializeField] private float speedRelative = 1.2f;
        private float speed = 2;
        public override void Move()
        {
            transform.position += Vector3.left * speed * speedRelative * Time.deltaTime;
        }

    }
}
