using SweetGame;

public interface IInputService: IService
{
    bool IsJumpButtonDown { get; }
    bool AttackButtonUp { get; }
}