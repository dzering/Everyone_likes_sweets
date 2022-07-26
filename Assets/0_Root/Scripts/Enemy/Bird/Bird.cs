﻿using UnityEngine;
using SweetGame.Abstractions;
using SweetGame.Enemy.States;


namespace SweetGame.Enemy
{
    public class Bird : EnemyBase, IFly
    {
        private int _amountAttack = 1;
        private int _currentAttack;

        private BirdView _view;
        private StateBase _state;

        private float _speedRelative = 1;
        private float _speedGame;
        private float _speed;
        public override float Speed 
        {
            get {return _speed; }
        }
        public override Vector3 Position
        {
            get { return _view.transform.position; }
            set
            {
                _view.transform.position = value;
            }
        }

        public Bird(float speed)
        {
            _speedGame = speed;
            _speed = _speedGame * _speedRelative;
            _view = LoadView();
            _state = new PatrolState(this);
            EnemiAI = new BirdAI(this);

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
            base.Execute();
            EnemiAI.Execute();
        }

        public override void Move()
        {
            _state.Move(Speed);
        }
        public override void ChangeState(StateBase state)
        {
            if (_currentAttack > _amountAttack)
                return;

            _state = state;
            _currentAttack++;
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
