using UnityEngine;
using SweetGame.Abstractions;
using SweetGame.Animations;

namespace SweetGame.Enemy
{
    public class Bird : EnemyBase
    {
        [SerializeField] private float speedRelative = -1.5f;
        private float speed = 2f;
        private StateBase _state;


        private void Start()
        {
            SpriteAnimator.instance.StartAnimation(GetComponent<SpriteRenderer>(), Track.Bird_1_fly, true, 10);
        }
        public override void Move()
        {
            transform.position += Vector3.left * speed * speedRelative * Time.deltaTime;
            _state.Move();

        }

        public override void Interaction()
        {
            base.Interaction();

        }
    }
}
