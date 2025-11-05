using UnityEngine;
using Zenject;

public class MovementAnimationUpdater : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;

    private IInputService _inputService;
    private PlayerAnimatorConfig _config;
    
    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }
    
    public void Initialize(PlayerAnimatorConfig playerAnimatorConfig) => 
        _config = playerAnimatorConfig;
    
    private void Update() => 
        UpdateMovementAnimation();

    private void UpdateMovementAnimation()
    {
        bool isMoving = _inputService.Direction.magnitude > 0;
        float moveSpeedMultiplier = isMoving ? _config.RunSpeedMultiplier : _config.IdleSpeedMultiplier;
        
        if (isMoving) _playerAnimator.LaunchRunAnimation(_config.CrossFadeDuration);
        else _playerAnimator.LaunchIdleAnimation(_config.CrossFadeDuration);
        
        _playerAnimator.SetMovementAnimationSpeed(moveSpeedMultiplier);
    }
}
