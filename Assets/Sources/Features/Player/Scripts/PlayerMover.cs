using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class PlayerMover : MonoBehaviour
{
    [FormerlySerializedAs("_playerMovement")] [SerializeField] private CharacterMovement _characterMovement;
    
    private IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }

    private void Update() => 
        ApplyMoveDirection();
    
    private void ApplyMoveDirection() => 
        _characterMovement.MoveAt(_inputService.Direction);
}
