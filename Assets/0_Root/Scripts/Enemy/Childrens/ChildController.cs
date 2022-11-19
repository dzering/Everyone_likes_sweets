using UnityEngine;
using SweetGame.Abstractions;


namespace SweetGame.Enemy
{
    public sealed class ChildController : EnemyBase
    {
        private float speed = 2;
        private float _relativeSpeed;
        private ChildView _view;

        public ChildController(float relativeSpeed)
        {
            _relativeSpeed = relativeSpeed;
            _view = LoadView();
        }

        private ChildView LoadView()
        {
            GameObject pref = Resources.Load<GameObject>("Prefabs/Enemies/GirlView");
            GameObject obj = UnityEngine.Object.Instantiate(pref);

            return obj.GetComponent<ChildView>();
        }

        public override void Interaction()
        {
            throw new System.NotImplementedException();
        }

        public override void Move()
        {
            _view.transform.position += Vector3.left * speed * _relativeSpeed * Time.deltaTime;
        }

        public override void SetPosition(Vector3 position)
        {
            _view.transform.position = position;
        }

    }
}
