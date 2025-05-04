using UnityEngine;

public class SowAbility : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    
    public void Apply() => 
        _animator.LaunchSowAnimation();

    public void Stop() =>
        _animator.StopSowAnimation();
}