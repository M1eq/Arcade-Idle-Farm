using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private Dictionary<PlantType, PlantStaticData> _plants;
    
    public void LoadResources()
    {
        _plants = Resources.LoadAll<PlantStaticData>(StaticDataPath.PlantConfigsPath)
            .ToDictionary(x => x.PlantType, x => x);
    }
    
    public GameConfig GetGameConfig() => 
        Resources.Load<GameConfig>(StaticDataPath.GameConfigPath);

    public PlantStaticData GetPlantConfig(PlantType plantType) => 
        _plants[plantType];
}