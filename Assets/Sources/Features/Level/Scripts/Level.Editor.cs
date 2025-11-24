using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public partial class Level
{
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