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
        Vector3 moveDirection = direction * (_config.MoveSpeed * Time.deltaTime) / Screen.width;
        _characterController.Move(moveDirection);

        if (moveDirection.normalized != Vector3.zero)
            _rendererTransform.forward = moveDirection.normalized;
    }
}