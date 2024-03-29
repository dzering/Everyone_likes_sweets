﻿using System;
using SweetGame.CodeBase.Abstractions;
using SweetGame.CodeBase.Enum;
using SweetGame.CodeBase.Game.Enemy.AI;
using SweetGame.CodeBase.Game.Enemy.States;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame.CodeBase.Game.Enemy.Bird
{
    public class Bird : EnemyBase, IFly, IDisposable
    {
        private readonly int _amountAttack = 1;
        private int _currentAttack;

        private readonly BirdView _view;
        private StateBase _state;

        private readonly float _speedRelative = 1;
        private readonly float _speedGame;
        private readonly float _speed;
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

            _view.OnCatchPlayer += CatchPlayer;
            _view.OnInteraction += Interaction;
        }

        ~Bird()
        {
            Debug.Log(nameof(Bird) + " Delited");
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

        public override void Interaction(InteractionType type)
        {
            switch (type)
            {
                case InteractionType.None:
                    break;
                case InteractionType.Deadly:
                    Died();
                    break;
                default:
                    break;
            }
        }

        private void Died()
        {
            Dispose();
        }

        public override void SetPosition(Vector3 position)
        {
            _view.transform.position = position;
        }

        public void Dispose()
        {
            OnDied?.Invoke(this);
            _view.OnCatchPlayer -= CatchPlayer;
            _view.OnInteraction -= Interaction;
            GameObject.Destroy(_view.gameObject);
            Debug.Log("Dispose " + nameof(Bird));
        }
    }
}
