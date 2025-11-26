using System.Collections.Generic;
using UnityEngine;

public partial class Level : MonoBehaviour
{
    [field: SerializeField] public LevelType LevelType { get; private set; }
    [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
    [field: Space(10), SerializeField] public List<Chunk> Chunks { get; private set; }
    
    public void SetChunksSettings(CropZoneConfig cropZoneConfig, PlantsSellZoneConfig plantSellZoneConfig)
    {
        foreach (var chunk in Chunks) 
            chunk.SetInteractionZonesSettings(cropZoneConfig, plantSellZoneConfig);
    }
    
    public void RestoreLevelBy(LevelData levelData)
    {
        foreach (var chunk in Chunks)
        {
            if (levelData.TryGetChunkDataBy(chunk.ID, out var chunkData)) 
                chunk.RestoreBy(chunkData);
        }
    }
    
    public List<ChunkData> GetChunksDataList()
    {
        List<ChunkData> chunksDataList = new();
        
        foreach (var chunk in Chunks)
        {
            ChunkData chunkData = new(chunk.GetCropZonesDataList());
            chunksDataList.Add(chunkData);
        }
        
        return chunksDataList;
    }
}