using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private Dictionary<PlantType, PlantStaticData> _plants;
    private Dictionary<InteractionButtonType, InteractionButtonStaticData> _interactionButtons;
    
    public void LoadResources()
    {
        _plants = Resources.LoadAll<PlantStaticData>(StaticDataPath.PlantConfigsPath)
            .ToDictionary(x => x.PlantType, x => x);
        
        _interactionButtons = Resources.LoadAll<InteractionButtonStaticData>(StaticDataPath.ButtonsConfigsPath)
            .ToDictionary(x => x.ButtonType, x => x);
    }
    
    public GameConfig GetGameConfig() => 
        Resources.Load<GameConfig>(StaticDataPath.GameConfigPath);

    public PlantStaticData GetPlantConfig(PlantType plantType) => 
        _plants[plantType];

    public InteractionButtonStaticData GetInteractionButtonConfig(InteractionButtonType type) => 
        _interactionButtons[type];
}