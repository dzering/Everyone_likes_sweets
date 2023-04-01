public abstract class InputService : IInputService
{
    protected const string BUTTON_FIRE = "Jump";
    public abstract bool IsJumpButtonDown { get; }
}