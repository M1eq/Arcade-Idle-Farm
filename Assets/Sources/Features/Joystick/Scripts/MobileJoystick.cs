using UnityEngine;
using Zenject;

public class MobileJoystick : MonoBehaviour
{
    [SerializeField] private RectTransform _joystickOutline;
    [SerializeField] private RectTransform _joystickKnob;

    private bool _isDragging;
    private IInputService _inputService;
    private Vector3 _joystickShowPosition;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }
    
    public void Show()
    {
        _joystickShowPosition = Input.mousePosition;
        _joystickOutline.position = _joystickShowPosition;
        
        _joystickOutline.gameObject.SetActive(true);
        _isDragging = true;
    }
    
    private void Update()
    {
        if (_inputService.InputBlocked || _isDragging == false)
            return;
        
        DragKnob();
            
        if (Input.GetMouseButtonUp(0))
            Hide();
    }

    private void Start() => 
        Hide();
    
    private void DragKnob()
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - _joystickShowPosition;
        
        float moveMagnitude = direction.magnitude * 540 / Screen.width;
        moveMagnitude = Mathf.Min(moveMagnitude, _joystickOutline.rect.width / 2);
        
        Vector3 dragMove = direction.normalized * moveMagnitude;
        Vector3 targetPosition = _joystickShowPosition + dragMove;
        
        _joystickKnob.position = targetPosition;
    }
    
    private void Hide()
    {
        _joystickOutline.gameObject.SetActive(false);
        _isDragging = false;
    }
}