using UnityEngine;

public class SowAbility : MonoBehaviour, IAbility
{
    [SerializeField] private CharacterAnimator _animator;
    
    public void Apply() => 
        _animator.LaunchSowAnimation();

    public void Stop() =>
        _animator.StopSowAnimation();
}