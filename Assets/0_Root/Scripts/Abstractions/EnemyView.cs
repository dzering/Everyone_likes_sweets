using SweetGame.Enemy;

namespace SweetGame.Abstractions
{
    public abstract class EnemyView : ViewBase 
    {
        public abstract void Interaction(InteractionType type);
    }
}
