using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public sealed class ChunkData
{
    [field: SerializeField] public String ID { get; private set; }
    [field: SerializeField] public List<CropZoneData> CropZonesDataList { get; private set; }
    
    public bool TryGetCropZoneDataBy(string id, out CropZoneData cropZoneData)
    {
        cropZoneData = CropZonesDataList.FirstOrDefault(x => x.ID == id);
        return cropZoneData != null;
    }
}