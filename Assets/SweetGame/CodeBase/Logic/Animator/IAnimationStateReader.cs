using SweetGame.CodeBase.Animators;

namespace SweetGame.CodeBase.Logic.Animator
{
    public interface IAnimationStateReader
    {
        AnimatorState State { get;}
        void EnteredState(int hashState);
        void ExitState(int hashState);
    }
}