using SweetGame;

public abstract class InputService : IInputService
{
    protected const string JUMP_BUTTON = "Jump";
    protected const string FIRE_BUTTON = "Fire";
    public abstract bool IsJumpButtonDown { get; }
    public abstract bool AttackButtonUp { get; }
}