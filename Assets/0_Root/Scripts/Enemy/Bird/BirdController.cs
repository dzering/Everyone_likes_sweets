using UnityEngine;
using SweetGame.Abstractions;
using SweetGame.Enemy.States;

namespace SweetGame.Enemy
{
    internal class BirdController : EnemyBase
    {
        private float speedRelative = 1;
        private float _gameSpeed;
        private BirdView _view;
        private StateBase _state;

        public BirdController(float speed)
        {
            this._gameSpeed = speed;
            _view = LoadView();
            _state = new PatrolState(this);

            _view.OnChatchPlayer += CatchPlayer;
        }
        
        private BirdView LoadView()
        {
            GameObject pref = Resources.Load<GameObject>("Prefabs/Enemies/BirdView");
            GameObject obj =  Object.Instantiate(pref);

            return obj.GetComponent<BirdView>();
        }

        public override void Execute()
        {
            Move();
        }

        public override void Move()
        {
            _view.transform.position += Vector3.left * _gameSpeed * speedRelative * Time.deltaTime;
            _state.Move();
        }

        public void ChangeState(StateBase state)
        {
            _state = state;
        }

        public void CatchPlayer() { }

        public override void Interaction()
        {
            throw new System.NotImplementedException();
        }

        public override void SetPosition(Vector3 position)
        {
            _view.transform.position = position;
        }
    }
}
