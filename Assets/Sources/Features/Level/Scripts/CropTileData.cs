using System;
using UnityEngine;

[Serializable]
public sealed class CropTileData
{
    [field: SerializeField] public String ID { get; private set; }
    [field: SerializeField] public CropTileState CropTileState { get; private set; }
}