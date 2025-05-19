using UnityEngine;

public class HarvestAbility : MonoBehaviour, IAbility
{
    [SerializeField] private PlayerAnimator _animator;
    
    public void Apply() => 
        _animator.LaunchHarvestAnimation();

    public void Stop() => 
        _animator.StopHarvestAnimation();
}
