using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float MoveSpeed = 5;

    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _rendererTransform;

    public void MoveAt(Vector3 direction)
    {
        Vector3 moveDirection = direction * (MoveSpeed * Time.deltaTime) / Screen.width;
        _characterController.Move(moveDirection);

        if (moveDirection.normalized != Vector3.zero)
            _rendererTransform.forward = moveDirection.normalized;
    }
}