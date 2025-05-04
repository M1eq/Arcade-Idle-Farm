using UnityEngine;

public class MovementAnimationLauncher : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;

    private void Update() => 
        _playerAnimator.UpdateMovementAnimation();
}
