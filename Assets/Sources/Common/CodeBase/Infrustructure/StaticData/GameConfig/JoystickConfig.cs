using System;
using UnityEngine;

[Serializable]
public class JoystickConfig 
{
    [field: SerializeField] public float KnobMovementLimitFactor { get; private set; } = 2.5f;
    [field: SerializeField] public float KnobMovementSensivity { get; private set; } = 1f;
}
