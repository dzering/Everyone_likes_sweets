using SweetGame.Enemy;

namespace SweetGame.Abstractions
{
    public abstract class EnemyBase : InteractiveObject, IMove
    {
        public ViewBase View { get; set; }
        public abstract void Move();
        public override void Execute()
        {
            base.Execute();
            Move();
        }
    }
}