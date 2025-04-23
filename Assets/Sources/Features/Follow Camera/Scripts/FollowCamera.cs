using Unity.Cinemachine;
using UnityEngine;
using Zenject;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _cinemachineCamera;
    [SerializeField] private CinemachineFollow _cinemachineFollow;

    private bool CantZoom => _cinemachineCamera.Follow == null || _inputService.InputBlocked;
    
    private IInputService _inputService;
    private FollowCameraConfig _config;
    private Vector3 _targetOffset;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }

    public void Initialize(FollowCameraConfig config) => 
        _config = config;

    public void SetTarget(Transform target) =>
        _cinemachineCamera.Follow = target;

    private void Update() => 
        UpdateZoom();

    private void UpdateZoom()
    {
        if (CantZoom)
            return;
        
        _targetOffset = _inputService.Direction == Vector3.zero ? _config.IdleZoom : _config.MoveZoom;

        _cinemachineFollow.FollowOffset = Vector3.Lerp(
            _cinemachineFollow.FollowOffset,
            _targetOffset,
            _config.ZoomSpeed * Time.deltaTime);
    }
}