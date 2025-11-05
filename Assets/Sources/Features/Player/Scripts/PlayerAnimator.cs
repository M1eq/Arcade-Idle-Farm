using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const int SowLayerIndex = 1;
    private const int WaterLayerIndex = 2;
    private const int HarvestLayerIndex = 3;
    
    [SerializeField] private Animator _animator;
    
    private int _currentMovementHash;
    
    public void LaunchWaterAnimation() => 
        _animator.SetLayerWeight(WaterLayerIndex, 1);

    public void StopWaterAnimation() => 
        _animator.SetLayerWeight(WaterLayerIndex, 0);

    public void LaunchSowAnimation() =>
        _animator.SetLayerWeight(SowLayerIndex, 1);
    
    public void StopSowAnimation() =>
        _animator.SetLayerWeight(SowLayerIndex, 0);

    public void LaunchHarvestAnimation() => 
        _animator.SetLayerWeight(HarvestLayerIndex, 1);

    public void StopHarvestAnimation() => 
        _animator.SetLayerWeight(HarvestLayerIndex, 0);
    
    public void LaunchRunAnimation(float crossFadeDuration = 0) => 
        SetMovementAnimation(CharacterAnimationsHash.Run, crossFadeDuration);

    public void LaunchIdleAnimation(float crossFadeDuration = 0) => 
        SetMovementAnimation(CharacterAnimationsHash.Idle, crossFadeDuration);
    
    public void SetMovementAnimationSpeed(float moveSpeedValue) => 
        _animator.SetFloat(CharacterAnimationsHash.MoveSpeedMultiplierParameter, moveSpeedValue);
    
    private void SetMovementAnimation(int targetAnimationHash, float crossFadeDuration)
    {
        if (_currentMovementHash == targetAnimationHash) 
            return;
        
        _animator.CrossFade(targetAnimationHash,  crossFadeDuration, 0);
        _currentMovementHash = targetAnimationHash;
    }
}