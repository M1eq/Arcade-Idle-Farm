using Cysharp.Threading.Tasks;

public interface IStaticDataService
{
    public GameConfig GameConfig { get; }
    UniTask LoadStaticData();
    PlantStaticData GetPlantConfig(PlantType plantType);
    InteractionButtonStaticData GetInteractionButtonConfig(InteractionButtonType type);
}