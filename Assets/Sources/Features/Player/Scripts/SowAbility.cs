using UnityEngine;

public class SowAbility : MonoBehaviour, IAbility
{
    [SerializeField] private PlayerAnimator _animator;
    
    public void Apply() => 
        _animator.LaunchSowAnimation();

    public void Stop() =>
        _animator.StopSowAnimation();
}