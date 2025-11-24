using System.Collections.Generic;
using UnityEngine;

public partial class Level : MonoBehaviour
{
    [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
    [field: SerializeField] public LevelType LevelType { get; private set; }

    [field: Space(10), SerializeField] public List<CropZone> CropZones { get; private set; }
    [field: SerializeField] public List<PlantsSellZone> PlantSellZones { get; private set; }
    
    public void InitializeInteractionZones(CropZoneConfig cropZoneConfig, PlantsSellZoneConfig plantSellZoneConfig)
    {
        foreach (var cropZone in CropZones)
            cropZone.Initialize(cropZoneConfig);

        foreach (var plantSellZone in PlantSellZones)
            plantSellZone.Initialize(plantSellZoneConfig);
    }

    public void RestoreLevelBy(LevelData levelData)
    {
    }
}