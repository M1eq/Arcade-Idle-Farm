using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class MobileJoystickZone : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private MobileJoystick _joystick;
    
    private IInputService _inputService;

    [Inject]
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