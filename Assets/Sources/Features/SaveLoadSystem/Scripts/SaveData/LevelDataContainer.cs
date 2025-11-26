using System;
using UnityEngine;

[Serializable]
public sealed class LevelDataContainer
{
    [field: SerializeField] public LevelType LevelType { get; private set; }
    [field: SerializeField] public LevelData LevelData { get; private set; }

    public LevelDataContainer(LevelType levelType, LevelData levelData)
    {
        LevelType = levelType;
        LevelData = levelData;
    }
    
    public LevelDataContainer Clone()
    {
        LevelData levelDataClone = LevelData.Clone();
        return new LevelDataContainer(LevelType, levelDataClone);
    }
    
    public void UpdateLevelData(LevelData levelData) => 
        LevelData = levelData;
}