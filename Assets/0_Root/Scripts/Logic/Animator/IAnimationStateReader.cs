namespace SweetGame.Enemy
{
    public interface IAnimationStateReader
    {
        AnimatorState State { get;}
        void EnteredState(int hashState);
        void ExitState(int hashState);
    }
}