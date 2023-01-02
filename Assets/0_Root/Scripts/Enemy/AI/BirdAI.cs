using UnityEngine;
using SweetGame.Game.Utility;
using SweetGame.Abstractions;
using SweetGame.Enemy.States;


namespace SweetGame.Enemy
{
    public sealed class BirdAI : EnemiAI
    {
        private const float DISTANCE_TO_TARGET = 7f;
        private const float TIME_INTERVAL_CHECKING = 0.2f;

        private EnemyBase _enemy;
        private ITimer _timer;

        private bool _isCurrent;


        public BirdAI(EnemyBase enemy)
        {
            _enemy = enemy;
            _timer = new Timer(TIME_INTERVAL_CHECKING);
            PlayerTransform = UnityEngine.Object.FindObjectOfType<PlayerViewBase>().transform;
            _timer.OnAlarm += Checks;
        }

        public override void Execute()
        {
            _timer.Execute();
        }

        private void Checks()
        {
            var result = CheckDistanceToTarget(PlayerTransform);

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

            Debug.DrawLine(PlayerTransform.position, _enemy.Position, color, 10f);
            Debug.Log(result);
            #endregion

            return result;
        }
    }
}

