namespace SweetGame.CodeBase.Infrastructure.Services.Input
{
    public interface IInputService: IService
    {
        bool IsJumpButtonDown { get; }
        bool AttackButtonUp { get; }
    }
}