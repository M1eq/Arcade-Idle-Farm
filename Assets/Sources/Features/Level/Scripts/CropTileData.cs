using System;
using UnityEngine;

[Serializable]
public sealed class CropTileData
{
    [field: SerializeField] public String ID { get; private set; }
    [field: SerializeField] public CropTileState CropTileState { get; private set; }

    public CropTileData(string id, CropTileState cropTileState)
    {
        ID = id;
        CropTileState = cropTileState;
    }

    public CropTileData CloneData() => 
        new(ID, CropTileState);
}