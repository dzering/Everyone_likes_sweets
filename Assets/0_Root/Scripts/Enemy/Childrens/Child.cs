using UnityEngine;
using SweetGame.Abstractions;


namespace SweetGame.Enemy
{
    public sealed class Child : EnemyBase, IGround
    {
        private float _relativeSpeed = 2;
        private ChildView _view;

        private float _speedCummulative;
        public override Vector3 Position 
        {
            get {return _view.transform.position; }
            set { _view.transform.position = value; } 
        }
        public override float Speed 
        {
            get { return _speedCummulative; }
        }


        public Child(float gameSpeed)
        {
            _view = LoadView();
            _speedCummulative = _relativeSpeed * gameSpeed;
        }

        private ChildView LoadView()
        {
            GameObject pref = Resources.Load<GameObject>("Prefabs/Enemies/Child");
            GameObject obj = UnityEngine.Object.Instantiate(pref);

            return obj.GetComponent<ChildView>();
        }

        public override void Interaction(InteractionType type)
        {
            throw new System.NotImplementedException();
        }

        public override void Move()
        {
            _view.transform.position += Vector3.left * _speedCummulative * Time.deltaTime;
        }

        public override void SetPosition(Vector3 position)
        {
            _view.transform.position = position;
        }

        public override void ChangeState(StateBase state)
        {
            throw new System.NotImplementedException();
        }
    }
}
