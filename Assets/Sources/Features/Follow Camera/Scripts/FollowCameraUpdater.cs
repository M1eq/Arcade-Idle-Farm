using UnityEngine;
using Zenject;

public class FollowCameraUpdater : MonoBehaviour
{
    private bool CanZoom => _inputService.InputBlocked == false && _followCamera.HasFollowTarget;
    
    [SerializeField] private FollowCamera _followCamera;
    
    private IInputService _inputService;
    private FollowCameraConfig _config;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }
    
    public void Initialize(FollowCameraConfig config) => 
        _config = config;
    
    private void Update()
    {
        if (CanZoom) 
            UpdateZoom();
    }

    private void UpdateZoom()
    {
        Vector3 targetZoom = _inputService.Direction == Vector3.zero ? _config.IdleZoom : _config.MoveZoom;
        _followCamera.UpdateZoom(targetZoom, _config.ZoomSpeed);
    }
}
