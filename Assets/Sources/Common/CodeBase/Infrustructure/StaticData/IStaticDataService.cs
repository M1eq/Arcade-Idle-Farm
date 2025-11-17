using Cysharp.Threading.Tasks;

public interface IStaticDataService
{
    public GameConfig GameConfig { get; }
    UniTask LoadStaticData();
    LevelStaticData GetLevelConfig(LevelType type);
    PlantStaticData GetPlantConfig(PlantType plantType);
    InteractionButtonStaticData GetInteractionButtonConfig(InteractionButtonType type);
}