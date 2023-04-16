public class InputServiceStandalone : InputService
{
    public override bool IsJumpButtonDown => UnityEngine.Input.GetButtonDown(JUMP_BUTTON);
    public override bool AttackButtonUp => UnityEngine.Input.GetButtonDown(FIRE_BUTTON);
}