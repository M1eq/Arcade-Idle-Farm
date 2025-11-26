using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public sealed class WorldData : ISaveData
{
    [SerializeField] private List<LevelDataContainer> _levelDataContainers;
    [field: SerializeField] public LevelType LastSavedLevelType { get; private set; }

    public WorldData(List<LevelDataContainer> levelDataContainers, LevelType lastSavedLevelType)
    {
        _levelDataContainers = levelDataContainers;
        LastSavedLevelType = lastSavedLevelType;
    }
    
    public bool EqualsData(WorldData data) =>
        true;

    public WorldData Clone()
    {
        List<LevelDataContainer> levelDataContainersClone = new();
        
        foreach (var levelDataContainer in _levelDataContainers) 
            levelDataContainersClone.Add(levelDataContainer.Clone());
        
        return new WorldData(levelDataContainersClone, LastSavedLevelType);
    }

    public bool TryGetLevelDataFor(LevelType levelType, out LevelData levelData)
    {
        levelData = null;
        var levelDataContainer = _levelDataContainers.FirstOrDefault(x => x.LevelType == levelType);

        if (levelDataContainer != null)
        {
            levelData = levelDataContainer.LevelData;
            return true;
        }

        return false;
    }

    public void UpdateLevelDataFor(LevelType levelType, Level level)
    {
        var levelDataContainer = _levelDataContainers.FirstOrDefault(x => x.LevelType == levelType);
        LevelData saveData = new LevelData(level.GetChunksDataList());

        if (levelDataContainer != null)
            levelDataContainer.UpdateLevelData(saveData);
        else
            AddNewLevelDataContainer(levelType, saveData);

        LastSavedLevelType = levelType;
    }

    private void AddNewLevelDataContainer(LevelType levelType, LevelData saveData)
    {
        var newLevelDataContainer = new LevelDataContainer(levelType, saveData);
        _levelDataContainers.Add(newLevelDataContainer);
    }
}