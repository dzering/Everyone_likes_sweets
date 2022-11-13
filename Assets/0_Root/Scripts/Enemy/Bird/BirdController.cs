using UnityEngine;
using SweetGame.Abstractions;
using SweetGame.Enemy.States;

namespace SweetGame.Enemy
{
    internal class BirdController : EnemyBase
    {
        private float speedRelative;
        private float speed;
        private BirdView view;
        private StateBase _state;

        public BirdController(float speed)
        {
            this.speed = speed;
            view = LoadView();
            _state = new PatrolState(this);
        }
        
        private BirdView LoadView()
        {
            GameObject pref = Resources.Load<GameObject>("Prefabs/Enemies/BirdView");
            GameObject obj =  Object.Instantiate(pref);

            return obj.GetComponent<BirdView>();
        }

        public override void Move()
        {
            view.transform.position += Vector3.left * speed * speedRelative * Time.deltaTime;
            _state.Move();
        }
    }
}
