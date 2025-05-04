using UnityEngine;

public class SowAbillity
{
    [SerializeField] private PlayerAnimator _animator;
    
    public void Apply() => 
        _animator.PlaySowAnimation();
}