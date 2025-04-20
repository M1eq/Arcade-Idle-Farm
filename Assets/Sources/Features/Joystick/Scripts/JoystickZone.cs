using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class JoystickZone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Joystick _joystick;

    private IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }

    public void OnPointerDown(PointerEventData eventData) =>
        ShowJoystickAt(eventData.position);

    public void OnPointerUp(PointerEventData eventData) =>
        HideJoystick();
    
    private void Update() =>
        UpdateJoystickDragging();

    private void Start() =>
        HideJoystick();

    private void HideJoystick() =>
        _joystick.Hide();

    private void UpdateJoystickDragging()
    {
        if (_inputService.InputBlocked || _joystick.IsDragging == false)
            return;

        _joystick.DragKnob();
    }

    private void ShowJoystickAt(Vector3 position)
    {
        if (_inputService.InputBlocked)
            return;

        _joystick.ShowAt(position);
    }
}