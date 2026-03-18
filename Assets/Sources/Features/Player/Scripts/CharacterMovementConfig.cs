using System;
using UnityEngine;

[Serializable]
public class CharacterMovementConfig
{
    [field: SerializeField] public float MoveSpeed { get; private set; } = 25;
}