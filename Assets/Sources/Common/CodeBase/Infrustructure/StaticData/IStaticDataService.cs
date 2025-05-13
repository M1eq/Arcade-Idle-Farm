public interface IStaticDataService
{
    void LoadResources();
    GameConfig GetGameConfig();
    PlantStaticData GetPlantConfig(PlantType plantType);
    InteractionButtonStaticData GetInteractionButtonConfig(InteractionButtonType type);
}