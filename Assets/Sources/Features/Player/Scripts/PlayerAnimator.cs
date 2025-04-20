using UnityEngine;
using Zenject;

public class PlayerAnimator : MonoBehaviour
{
    private const float CrossFadeDuration = 0.15f;
    private const float RunSpeedMultiplier = 1.25f;
    private const float IdleSpeedMultiplier = 1f;

    [SerializeField] private Animator _animator;

    private int _currentMovementHash;
    private IInputService _inputService;
    private readonly PlayerAnimationsHash _animationsHash = new();

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }

    public void UpdateMovementAnimation()
    {
        bool isMoving = _inputService.Direction.magnitude > 0;
        
        int targetAnimationHash = isMoving ? _animationsHash.Run : _animationsHash.Idle;
        float moveSpeedMultiplier = isMoving ? RunSpeedMultiplier : IdleSpeedMultiplier;

        CrossFadeMovementAnimation(targetAnimationHash);
        SetMoveSpeedMultiplier(moveSpeedMultiplier);
    }
    
    private void CrossFadeMovementAnimation(int targetAnimationHash)
    {
        if (_currentMovementHash == targetAnimationHash) 
            return;
        
        _animator.CrossFade(targetAnimationHash, CrossFadeDuration, 0);
        _currentMovementHash = targetAnimationHash;
    }
    
    private void SetMoveSpeedMultiplier(float moveSpeedValue) => 
        _animator.SetFloat(_animationsHash.MoveMultiplierParameter, moveSpeedValue);
}