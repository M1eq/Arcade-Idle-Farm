using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystickZone : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private MobileJoystick _joystick;
    
    private IInputService _inputService;

    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_inputService.InputBlocked)
            return;

        _joystick.Show();
    }
}