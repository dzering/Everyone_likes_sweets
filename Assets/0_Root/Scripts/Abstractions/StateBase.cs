using SweetGame.Abstractions;


namespace SweetGame.Abstractions
{
    public abstract class StateBase
    {
        protected EnemyBase _enemy;

        public StateBase(EnemyBase enemy)
        {
            _enemy = enemy;
        }

        public abstract void Move();
    }
}
