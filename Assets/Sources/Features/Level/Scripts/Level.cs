using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Level : MonoBehaviour
{
    [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
    
    [SerializeField] private List<CropZone> _cropZones;
    [SerializeField] private List<PlantsSellZone> _plantSellZones;

    public void InitializeCropZones(CropZoneConfig cropZoneConfig)
    {
        foreach (var cropZone in _cropZones) 
            cropZone.Initialize(cropZoneConfig);
    }

    public void InitializePlantSellZones(PlantsSellZoneConfig plantSellZoneConfig)
    {
        foreach (var plantSellZone in _plantSellZones) 
            plantSellZone.Initialize(plantSellZoneConfig);
    }

    [Button("Collect")]
    private void CollectInitializationTargets()
    {
        _cropZones.Clear();
        _plantSellZones.Clear();
    
        _cropZones.AddRange(GetComponentsInChildren<CropZone>(true));
        _plantSellZones.AddRange(GetComponentsInChildren<PlantsSellZone>(true));
    }
} 