using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class JoystickZone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Joystick _joystick;

    private bool CanUpdateJoystickDragging => _inputService.InputBlocked == false && _joystick.IsDragging;
    
    private IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_inputService.InputBlocked == false)
            ShowJoystickAt(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData) =>
        HideJoystick();

    private void Update()
    {
        if (CanUpdateJoystickDragging)
            UpdateJoystickDragging();
    }

    private void Start() =>
        HideJoystick();

    private void HideJoystick() =>
        _joystick.Hide();

    private void UpdateJoystickDragging() =>
        _joystick.DragKnob();

    private void ShowJoystickAt(Vector3 position) =>
        _joystick.ShowAt(position);
}