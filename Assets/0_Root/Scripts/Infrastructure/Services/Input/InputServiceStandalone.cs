public class InputServiceStandalone : InputService
{
    public override bool IsJumpButtonDown => UnityEngine.Input.GetButtonDown(BUTTON_FIRE);
}