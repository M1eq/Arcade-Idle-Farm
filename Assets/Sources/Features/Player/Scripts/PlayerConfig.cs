using System;
using UnityEngine;

[Serializable]
public class PlayerConfig
{
    [field: SerializeField] public PlayerMovementConfig MovementConfig { get; private set; }
    [field: SerializeField] public PlayerAnimatorConfig AnimatorConfig { get; private set; }
    [field: SerializeField] public FollowCameraConfig FollowCameraConfig { get; private set; }
}