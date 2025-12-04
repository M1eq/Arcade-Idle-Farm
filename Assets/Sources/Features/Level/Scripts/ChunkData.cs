using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public sealed class ChunkData
{
    [field: SerializeField] public String ID { get; private set; }
    [field: SerializeField] public List<CropZoneData> CropZonesDataList { get; private set; }
    
    public ChunkData(String id, List<CropZoneData> cropZoneDataList)
    {
        ID = id;
        CropZonesDataList = cropZoneDataList;
    }
    
    public bool TryGetCropZoneDataBy(string id, out CropZoneData cropZoneData)
    {
        cropZoneData = CropZonesDataList.FirstOrDefault(x => x.ID == id);
        return cropZoneData != null;
    }

    public ChunkData CloneData()
    {
        List<CropZoneData> newCropZonesDataList = new();

        foreach (var cropZoneData in CropZonesDataList) 
            newCropZonesDataList.Add(cropZoneData.CloneData());
        
        return new ChunkData(ID, newCropZonesDataList); 
    }
}