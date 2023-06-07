namespace SweetGame.CodeBase.Infrastructure.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string JUMP_BUTTON = "Jump";
        protected const string FIRE_BUTTON = "Fire";
        protected const string PAUSE_BUTTON = "Pause";
        public abstract bool IsJumpButtonDown { get; }
        public abstract bool AttackButtonUp { get; }
        public abstract bool PauseButtonDown { get; }
    }
}