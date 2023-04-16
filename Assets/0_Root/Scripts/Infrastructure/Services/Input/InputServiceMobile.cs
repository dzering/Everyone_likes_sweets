public class InputServiceMobile : InputService
{
    public override bool IsJumpButtonDown =>  SimpleInput.GetButtonDown(JUMP_BUTTON);
    public override bool AttackButtonUp => SimpleInput.GetButtonDown(FIRE_BUTTON);
}

