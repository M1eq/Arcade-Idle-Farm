using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public sealed class CropZoneData
{
    [field: SerializeField] public String ID { get; private set; }
    [field: SerializeField] public CropZoneInteractionType InteractionType { get; private set; }
    [field: SerializeField] public List<CropTileData> SowedCropTilesData { get; private set; }
    [field: SerializeField] public List<CropTileData> WateredCropTilesData { get; private set; }
    [field: SerializeField] public List<CropTileData> HarvestedCropTilesData { get; private set; }
    
    public CropZoneData(String id, CropZoneInteractionType interactionType, 
        List<CropTileData> sowedCropTiles, List<CropTileData> wateredTiles, List<CropTileData> harvestedCropTiles)
    {
        ID = id;
        InteractionType = interactionType;
        SowedCropTilesData = sowedCropTiles;
        WateredCropTilesData = wateredTiles;
        HarvestedCropTilesData = harvestedCropTiles;
    }
    
    public CropZoneData CloneData()
    {
        List<CropTileData> newSowedCropTilesData = new(SowedCropTilesData);
        List<CropTileData> newWateredCropTilesData = new(WateredCropTilesData);
        List<CropTileData> newHarvestedCropTilesData = new(HarvestedCropTilesData);
        
        return new CropZoneData(ID, InteractionType,
            newSowedCropTilesData, newWateredCropTilesData, newHarvestedCropTilesData);
    }
}