using UnityEngine;
using Zenject;

public class PlayerAnimator : MonoBehaviour
{
    private const int SowLayerIndex = 1;
    
    [SerializeField] private Animator _animator;

    private readonly PlayerAnimationsHash _animationsHash = new();
    
    private int _currentMovementHash;
    private IInputService _inputService;
    private PlayerAnimatorConfig _config;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }

    public void Initialize(PlayerAnimatorConfig playerAnimatorConfig) => 
        _config = playerAnimatorConfig;

    public void LaunchSowAnimation() =>
        _animator.SetLayerWeight(SowLayerIndex, 1);
    
    public void StopSowAnimation() =>
        _animator.SetLayerWeight(SowLayerIndex, 0);

    public void UpdateMovementAnimation()
    {
        bool isMoving = _inputService.Direction.magnitude > 0;
        
        int targetAnimationHash = isMoving ? _animationsHash.Run : _animationsHash.Idle;
        float moveSpeedMultiplier = isMoving ? _config.RunSpeedMultiplier : _config.IdleSpeedMultiplier;

        CrossFadeMovementAnimation(targetAnimationHash);
        SetMoveSpeedMultiplier(moveSpeedMultiplier);
    }
    
    private void CrossFadeMovementAnimation(int targetAnimationHash)
    {
        if (_currentMovementHash == targetAnimationHash) 
            return;
        
        _animator.CrossFade(targetAnimationHash, _config.CrossFadeDuration, 0);
        _currentMovementHash = targetAnimationHash;
    }
    
    private void SetMoveSpeedMultiplier(float moveSpeedValue) => 
        _animator.SetFloat(_animationsHash.MoveMultiplierParameter, moveSpeedValue);
}