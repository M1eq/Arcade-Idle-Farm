using System;
using UnityEngine;

[Serializable]
public class FollowCameraConfig 
{
    [field: SerializeField] public Vector3 TrackOffset { get; private set; }
    [field: SerializeField] public float ZoomSpeed { get; private set; } = 2f;
    [field: Space(10), SerializeField] public Vector3 IdleZoom { get; private set; }
    [field: SerializeField] public Vector3 MoveZoom { get; private set; }
}
