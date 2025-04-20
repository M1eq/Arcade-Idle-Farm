using UnityEngine;

public interface IInputService
{
    bool InputBlocked { get; }
    Vector3 Direction { get; }
    void BlockInput();
    void UnblockInput();
}
