public class MobileJoystickInput : IInputService
{
    public bool InputBlocked { get; private set; }

    public void BlockInput() => 
        InputBlocked = true;

    public void UnblockInput() => 
        InputBlocked = false;
}
