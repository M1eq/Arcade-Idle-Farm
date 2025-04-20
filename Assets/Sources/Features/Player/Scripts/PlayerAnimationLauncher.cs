using UnityEngine;

public class PlayerAnimationLauncher : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;

    private void Update() => 
        _playerAnimator.UpdateMovementAnimation();
}
