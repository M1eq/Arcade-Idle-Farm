using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float MoveSpeed = 5;
    
    [SerializeField] private CharacterController _characterController;
    
    public void MoveAt(Vector3 direction)
    {
        Vector3 moveDirection = direction * (MoveSpeed * Time.deltaTime) / Screen.width;
        _characterController.Move(moveDirection);
    }
}
