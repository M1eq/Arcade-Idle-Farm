using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public sealed class LevelData
{
    [field: SerializeField] public List<ChunkData> ChunksDataList { get; private set; } 
    
    public LevelData(List<ChunkData> chunksDataList)
    {
        ChunksDataList = chunksDataList;
    }
    
    public bool TryGetChunkDataBy(string id, out ChunkData chunkData)
    {
        chunkData = ChunksDataList.FirstOrDefault(x => x.ID == id);
        return chunkData != null;
    }
    
    public LevelData CloneData()
    {
        List<ChunkData> newChunksDataList = new();

        foreach (var chunkData in ChunksDataList) 
            newChunksDataList.Add(chunkData.CloneData());
        
        return new LevelData(newChunksDataList);
    }
}