using Unity.Cinemachine;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public bool HasFollowTarget => _cinemachineCamera.Follow != null;

    [SerializeField] private CinemachineCamera _cinemachineCamera;
    [SerializeField] private CinemachineFollow _cinemachineFollow;

    public void SetTarget(Transform target) => 
        _cinemachineCamera.Follow = target;

    public void UpdateZoom(Vector3 zoom, float speed)
    {
        _cinemachineFollow.FollowOffset = Vector3.Lerp(
            _cinemachineFollow.FollowOffset,
            zoom,
            speed * Time.deltaTime);
    }
}