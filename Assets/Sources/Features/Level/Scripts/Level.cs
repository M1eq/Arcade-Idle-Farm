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
    
    # if UNITY_EDITOR
    
    [Button("Collect And SetID")]
    private void CollectInitializationTargets()
    {
        CropZones.Clear();
        PlantSellZones.Clear();

        CropZones.AddRange(GetComponentsInChildren<CropZone>(true));
        PlantSellZones.AddRange(GetComponentsInChildren<PlantsSellZone>(true));

        UpdateIDFor(CropZones);
        UpdateIDFor(PlantSellZones);
    }

    [Button("ResetIDS")]
    private void ResetInitializationTargetsID()
    {
        ResetIDFor(CropZones);
        ResetIDFor(PlantSellZones);
    }
    
    private void UpdateIDFor<T>(List<T> objectsWithId) where T : MonoBehaviour
    {
        foreach (T objectWithId in objectsWithId)
        {
            var ids = objectWithId.GetComponentsInChildren<UniqueID>(true);

            foreach (var uniqueID in ids) 
                uniqueID.UpdateID();
        }
    }
    
    private void ResetIDFor<T>(List<T> objectsWithId) where T : MonoBehaviour
    {
        foreach (T objectWithId in objectsWithId)
        {
            var ids = objectWithId.GetComponentsInChildren<UniqueID>(true);

            foreach (var uniqueID in ids) 
                uniqueID.ResetID();
        }
    }
    
    #endif
}