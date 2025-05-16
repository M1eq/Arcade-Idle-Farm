using UnityEngine;

public class Level : MonoBehaviour
{
    [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
    
    [SerializeField] private CropZone[] _cropZones;

    public void InitializeCropZones(CropZoneConfig cropZoneConfig)
    {
        foreach (var cropZone in _cropZones) 
            cropZone.Initialize(cropZoneConfig);
    }
}