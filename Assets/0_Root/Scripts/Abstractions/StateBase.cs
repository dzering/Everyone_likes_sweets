using SweetGame.Abstractions;


namespace SweetGame.Abstractions
{
    public abstract class StateBase
    {
        protected NewEnemyBase _enemy;

        public StateBase(NewEnemyBase enemy)
        {
            _enemy = enemy;
        }

        public abstract void Move();
    }
}
