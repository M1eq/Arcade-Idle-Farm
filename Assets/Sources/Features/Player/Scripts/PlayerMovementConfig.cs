using System;
using UnityEngine;

[Serializable]
public class PlayerMovementConfig
{
    [field: SerializeField] public float MoveSpeed { get; private set; } = 25;
}