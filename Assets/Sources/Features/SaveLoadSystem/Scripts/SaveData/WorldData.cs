using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public sealed class WorldData : ISaveData
{
    [SerializeField] private List<LevelDataContainer> _levelDataContainers;
    
    public bool EqualsData(WorldData data) => 
        true;

    public WorldData Clone() => 
        new();

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
    
    public void UpdateLevelDataFor(LevelType levelType, Level level) => 
        UpdateLevelCropsData();

    private void UpdateLevelCropsData()
    {
        
    }
}