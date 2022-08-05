using UnityEngine;
using SweetGame.Abstractions.Base;
using SweetGame.Animations;

namespace SweetGame.Enemy
{
    internal class Bird : EnemyBase
    {
        [SerializeField] private float speedRelative = -1.5f;
        private float speed = 2f;


        private void Start()
        {
            SpriteAnimator.instance.StartAnimation(GetComponent<SpriteRenderer>(), Track.Bird_1_fly, true, 10);
        }
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
