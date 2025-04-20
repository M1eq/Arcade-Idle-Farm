using UnityEngine;

public class MobileInput : IInputService
{
    public bool InputBlocked { get; private set; }
    public Vector3 Direction => InputBlocked ? Vector2.zero : _joystickInput.Direction;
    
    private readonly IJoystickInputReader _joystickInput;

    public MobileInput(IJoystickInputReader joystickInput)
    {
        _joystickInput = joystickInput;
    }
    
    public void BlockInput() => 
        InputBlocked = true;

    public void UnblockInput() => 
        InputBlocked = false;
}