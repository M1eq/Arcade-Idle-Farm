using UnityEngine;
using Zenject;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    
    private IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }

    private void Update() => 
        ApplyMoveDirection();
    
    private void ApplyMoveDirection() => 
        _playerMovement.MoveAt(_inputService.Direction);
}
