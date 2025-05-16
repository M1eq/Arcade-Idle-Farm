using System;
using UnityEngine;

[Serializable]
public class CropZoneConfig
{
    [field: SerializeField] public CropTileConfig CropTileConfig { get; private set; }
}