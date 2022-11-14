using SweetGame.Enemy;
using SweetGame.Abstractions;


namespace SweetGame.Abstractions
{
    public abstract class NewEnemyBase : IExecute
    {
        public ViewBase View { get; set; }

        public abstract void Execute();
    }
}