using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public partial class Level
{
# if UNITY_EDITOR

    #region Buttons

    [Button("Collect And SetID")]
    private void CollectTargetsAndSetID()
    {
        CollectChunks();
        CollectChunkTargets();
        UpdateIDFor(Chunks);
    }

    [Button("Reset IDS")]
    private void ResetTargetsID() =>
        ResetIDFor(Chunks);

    #endregion

    #region Logic
    
    private void CollectChunks()
    {
        Chunks.Clear();
        Chunks.AddRange(GetComponentsInChildren<Chunk>(true));
    }

    private void CollectChunkTargets()
    {
        foreach (var chunk in Chunks)
        {
            chunk.CropZones.Clear();
            chunk.PlantSellZones.Clear();

            chunk.CropZones.AddRange(chunk.GetComponentsInChildren<CropZone>(true));
            chunk.PlantSellZones.AddRange(chunk.GetComponentsInChildren<PlantsSellZone>(true));
        }
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

    #endregion
    
#endif
}