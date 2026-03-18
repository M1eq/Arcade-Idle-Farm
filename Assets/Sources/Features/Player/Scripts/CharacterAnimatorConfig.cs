using System;
using UnityEngine;

[Serializable]
public class CharacterAnimatorConfig
{
    [field: SerializeField] public float CrossFadeDuration { get; private set; } = 0.15f;
    [field: SerializeField] public float IdleSpeedMultiplier { get; private set; } = 1f;
    [field: SerializeField] public float RunSpeedMultiplier { get; private set; } = 1.25f;
}