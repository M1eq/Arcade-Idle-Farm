using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _rendererTransform;
    
    private PlayerMovementConfig _config;

    public void Initialize(PlayerMovementConfig config) => 
        _config = config;

    public void MoveAt(Vector3 direction)
    {
        if (direction != Vector3.zero)
            direction.Normalize();
        
        Vector3 moveDirection = direction * (_config.MoveSpeed * Time.deltaTime);
        _characterController.Move(moveDirection);
        
        if (moveDirection != Vector3.zero)
            _rendererTransform.forward = moveDirection.normalized;
    }
}