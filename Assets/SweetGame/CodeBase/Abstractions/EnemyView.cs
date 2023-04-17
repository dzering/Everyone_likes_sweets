using SweetGame.CodeBase.Enum;

namespace SweetGame.CodeBase.Abstractions
{
    public abstract class EnemyView : ViewBase 
    {
        public abstract void Interaction(InteractionType type);
    }
}
