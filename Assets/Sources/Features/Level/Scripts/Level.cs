using UnityEngine;

public class Level : MonoBehaviour
{
    [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
    
    [SerializeField] private CropZone[] _cropZones;
    [SerializeField] private PlantsSellZone[] _plantSellZones;

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
} 