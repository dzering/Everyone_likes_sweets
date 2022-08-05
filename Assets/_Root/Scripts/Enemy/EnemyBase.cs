using SweetGame.Abstractions;

namespace SweetGame.Abstractions.Base
{
    internal abstract class EnemyBase : InteractiveObject, IMove
    {
        public abstract void Move();
        public override void Execute()
        {
            base.Execute();
            Move();
        }
    }
}