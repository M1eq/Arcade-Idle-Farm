using UnityEngine;

public class JoystickInput : IJoystickInputWriter, IJoystickInputReader
{
    public Vector3 Direction { get; private set; }

    public void Update(Vector3 direction) =>
        SetInputDirection(direction);

    public void Reset() =>
        SetInputDirection(Vector3.zero);

    private void SetInputDirection(Vector3 direction) =>
        Direction = direction;
}