using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public sealed class ChunkData
{
    [field: SerializeField] public String ID { get; private set; }
    [field: Space(10), SerializeField] public List<CropZone> CropZones { get; private set; }
}