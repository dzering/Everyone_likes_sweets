namespace SweetGame.Enemy
{
    public interface IAnimationStateReader
    {
        void EnteredState(int hashState);
        void ExitState(int hashState);
        AnimatorState State { get;}
    }
}