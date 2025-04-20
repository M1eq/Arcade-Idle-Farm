using UnityEngine;
using Zenject;

public class Joystick : MonoBehaviour
{
    private const float KNOB_MOVEMENT_LIMIT_FACTOR = 1.5f;
    private const float KNOB_MOVEMENT_SENSIVITY = 1000;

    public bool IsDragging { get; private set; }

    [SerializeField] private RectTransform _joystickOutline;
    [SerializeField] private RectTransform _joystickKnob;

    private Vector3 _joystickShowPosition;
    private IJoystickInputWriter _inputWriter;

    [Inject]
    public void Construct(IJoystickInputWriter joystickInput)
    {
        _inputWriter = joystickInput;
    }

    public void ShowAt(Vector3 position)
    {
        _joystickShowPosition = position;
        _joystickOutline.position = _joystickShowPosition;
        SetJoystickActive(true);
    }

    public void Hide()
    {
        SetJoystickActive(false);
        _inputWriter.Reset();
    }

    public void DragKnob()
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - _joystickShowPosition;

        float moveMagnitude = direction.magnitude * KNOB_MOVEMENT_SENSIVITY / Screen.width;
        moveMagnitude = Mathf.Min(moveMagnitude, _joystickOutline.rect.width / KNOB_MOVEMENT_LIMIT_FACTOR);

        Vector3 knobDirection = direction.normalized * moveMagnitude;
        Vector3 targetKnobPosition = _joystickShowPosition + knobDirection;
        Vector3 targetDirection = new Vector3(knobDirection.x, 0, knobDirection.y);
        
        _joystickKnob.position = targetKnobPosition;
        _inputWriter.Update(targetDirection);
    }

    private void SetJoystickActive(bool active)
    {
        _joystickOutline.gameObject.SetActive(active);
        IsDragging = active;
    }
}