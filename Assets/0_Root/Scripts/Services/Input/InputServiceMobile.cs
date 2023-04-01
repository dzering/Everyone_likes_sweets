public class InputServiceMobile : InputService
{
    public override bool IsJumpButtonDown =>  SimpleInput.GetButtonDown(BUTTON_FIRE);
}

