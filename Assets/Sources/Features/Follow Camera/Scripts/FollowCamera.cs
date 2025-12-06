using Unity.Cinemachine;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public bool HasFollowTarget => _cinemachineCamera.Follow != null;

    [SerializeField] private CinemachineCamera _cinemachineCamera;
    [SerializeField] private CinemachineFollow _cinemachineFollow;
    [SerializeField] private CinemachineRotationComposer _cinemachineRotationComposer;

    public void SetTarget(Transform target) => 
        _cinemachineCamera.Follow = target;

    public void SetTrackOffset(Vector3 trackOffset) => 
        _cinemachineRotationComposer.TargetOffset = trackOffset;

    public void UpdateZoom(Vector3 zoom, float speed)
    {
        _cinemachineFollow.FollowOffset = Vector3.Lerp(
            _cinemachineFollow.FollowOffset,
            zoom,
            speed * Time.deltaTime);
    }
}