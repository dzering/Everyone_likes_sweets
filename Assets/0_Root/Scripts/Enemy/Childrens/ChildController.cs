using UnityEngine;
using SweetGame.Abstractions;


namespace SweetGame.Enemy
{
    public sealed class ChildController : EnemyBase, IGround
    {
        private float speed = 2;
        private float _relativeSpeed;
        private ChildView _view;
        public override Vector3 Position 
        {
            get {return _view.transform.position; }
            set { _view.transform.position = value; } 
        }

        public ChildController(float relativeSpeed)
        {
            _relativeSpeed = relativeSpeed;
            _view = LoadView();
        }

        private ChildView LoadView()
        {
            GameObject pref = Resources.Load<GameObject>("Prefabs/Enemies/Child");
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
