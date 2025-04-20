using UnityEngine;

public interface IJoystickInputWriter
{
    void Update(Vector3 direction);
    void Reset();
}