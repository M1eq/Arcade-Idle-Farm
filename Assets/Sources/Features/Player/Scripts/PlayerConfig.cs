using System;
using UnityEngine;

[Serializable]
public class PlayerConfig
{
    [field: SerializeField] public CharacterMovementConfig MovementConfig { get; private set; }
    [field: SerializeField] public CharacterAnimatorConfig AnimatorConfig { get; private set; }
    [field: SerializeField] public FollowCameraConfig FollowCameraConfig { get; private set; }
    [field: SerializeField] public BendingConfig BendingConfig { get; private set; }
    [field: SerializeField] public HarvestAbilityConfig HarvestAbilityConfig { get; set; }
}