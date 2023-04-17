using SweetGame.CodeBase.Enum;

namespace SweetGame.CodeBase.Abstractions
{
    public abstract class InteractiveObject:  IExecute
    {
        public abstract void Execute();
        public abstract void Interaction(InteractionType type);
    }
}
