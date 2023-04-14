using UnityEngine;
using SweetGame.Game.Utility;
using SweetGame.Abstractions;
using SweetGame.Enemy.States;


namespace SweetGame.Enemy
{
    public sealed class BirdAI : EnemiAI
    {
        private IGameFactory _gameFactory;
        private const float DISTANCE_TO_TARGET = 7f;
        private const float TIME_INTERVAL_CHECKING = 0.2f;

        private EnemyBase _enemy;
        private ITimer _timer;

        private bool _isCurrent;


        public BirdAI(EnemyBase enemy)
        {
            _enemy = enemy;
            _timer = new Timer(TIME_INTERVAL_CHECKING);
            _timer.OnAlarm += Checks;
            
            _gameFactory = AllServices.Container.Single<IGameFactory>();
            
            if(_gameFactory.Player != null)
                InitializePlayerTransform();
            else
            {
                _gameFactory.PlayerCreated += PlayerInitialize;
            }
        }

        private void PlayerInitialize()
        {
            InitializePlayerTransform();
        }

        private void InitializePlayerTransform()
        {
            Player = _gameFactory.Player.transform;
        }

        public override void Execute()
        {
            _timer.Execute();
        }

        private void Checks()
        {
            bool result = false;
            if(Player!=null) 
                result = CheckDistanceToTarget(Player);

            if (result == _isCurrent)
                return;

            if (result)
            {
                _isCurrent = result;
                _enemy.ChangeState(new AttackState(_enemy));
            }

            if (!result)
            {
                _isCurrent = result;
                _enemy.ChangeState(new PatrolState(_enemy));
            }

        }
        private bool CheckDistanceToTarget(Transform target)
        {
            var result = Measurer.CheckDistance(target.position, _enemy.Position, DISTANCE_TO_TARGET);

            #region Debug 
            Color color = Color.red;
            if(result)
                color = Color.green;

            Debug.DrawLine(Player.position, _enemy.Position, color, 10f);
            Debug.Log(result);
            #endregion

            return result;
        }
    }
}

