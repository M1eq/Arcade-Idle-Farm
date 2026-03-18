using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class MovementAnimationUpdater : MonoBehaviour
{
    [FormerlySerializedAs("_playerAnimator")] [SerializeField] private CharacterAnimator _characterAnimator;

    private IInputService _inputService;
    private CharacterAnimatorConfig _config;
    
    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }
    
    public void Initialize(CharacterAnimatorConfig characterAnimatorConfig) => 
        _config = characterAnimatorConfig;
    
    private void Update() => 
        UpdateMovementAnimation();

    private void UpdateMovementAnimation()
    {
        bool isMoving = _inputService.Direction.magnitude > 0;
        float moveSpeedMultiplier = isMoving ? _config.RunSpeedMultiplier : _config.IdleSpeedMultiplier;
        
        if (isMoving) _characterAnimator.LaunchRunAnimation(_config.CrossFadeDuration);
        else _characterAnimator.LaunchIdleAnimation(_config.CrossFadeDuration);
        
        _characterAnimator.SetMovementAnimationSpeed(moveSpeedMultiplier);
    }
}
