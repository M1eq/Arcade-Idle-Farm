using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Level : MonoBehaviour
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
    
    [Button("Collect")]
    private void CollectInitializationTargets()
    {
        CropZones.Clear();
        PlantSellZones.Clear();

        CropZones.AddRange(GetComponentsInChildren<CropZone>(true));
        PlantSellZones.AddRange(GetComponentsInChildren<PlantsSellZone>(true));
    }
}