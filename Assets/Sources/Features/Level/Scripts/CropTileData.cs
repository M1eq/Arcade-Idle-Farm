using System;
using UnityEngine;

[Serializable]
public sealed class CropTileData
{
    [field: SerializeField] public String ID { get; private set; }

    public CropTileData(string id)
    {
        ID = id;
    }
}