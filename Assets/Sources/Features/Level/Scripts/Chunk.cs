using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public string ID => _uniqueID.Id;
    
    [SerializeField] private UniqueID _uniqueID;
    [field: Space(10), SerializeField] public List<CropZone> CropZones { get; private set; }
    [field: SerializeField] public List<PlantsSellZone> PlantSellZones { get; private set; }
    
    public void SetInteractionZonesSettings(CropZoneConfig cropZoneConfig, PlantsSellZoneConfig plantSellZoneConfig)
    {
        foreach (var cropZone in CropZones)
            cropZone.Initialize(cropZoneConfig);

        foreach (var plantSellZone in PlantSellZones)
            plantSellZone.Initialize(plantSellZoneConfig);
    }

    public void RestoreBy(ChunkData chunkData)
    {
        foreach (var cropZone in CropZones)
        {
            if (chunkData.TryGetCropZoneDataBy(cropZone.ID, out var cropZoneData)) 
                cropZone.RestoreBy(cropZoneData);
        }
    }
    
    public List<CropZoneData> GetCropZonesDataList()
    {
        List<CropZoneData> cropZonesDataList = new();
        
        foreach (var cropZone in CropZones)
        {
            CropZoneData cropZoneData = new(
                cropZone.ID, cropZone.InteractionType, cropZone.GetSowedCropTilesData(),
                cropZone.GetWateredCropTilesData(), cropZone.GetHarvestedCropTilesData());
            
            cropZonesDataList.Add(cropZoneData);
        }
        
        return cropZonesDataList;
    }
}