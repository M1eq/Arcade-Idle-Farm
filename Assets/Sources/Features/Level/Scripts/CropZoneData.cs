using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public sealed class CropZoneData
{
    [field: SerializeField] public String ID { get; private set; }
    [field: SerializeField] public CropZoneInteractionType InteractionType { get; private set; }
    [field: SerializeField] public List<CropTileData> CropTilesDataList { get; private set; }
    
    public CropZoneData(String id, List<CropTileData> cropTilesDataList)
    {
        ID = id;
        CropTilesDataList = cropTilesDataList;
    }
    
    public bool TryGetCropTileDataBy(string id, out CropTileData cropTileData)
    {
        cropTileData = CropTilesDataList.FirstOrDefault(x => x.ID == id);
        return cropTileData != null;
    }
}