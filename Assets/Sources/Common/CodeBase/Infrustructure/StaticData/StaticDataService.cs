using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;

public class StaticDataService : IStaticDataService
{
    public GameConfig GameConfig { get; private set; }

    private readonly IAssetProvider _assetProvider;
    private readonly IGameProgressService _gameProgressService;
    
    private Dictionary<PlantType, PlantStaticData> _plants;
    private Dictionary<InteractionButtonType, InteractionButtonStaticData> _interactionButtons;

    public StaticDataService(IAssetProvider assetProvider, IGameProgressService gameProgressService)
    {
        _assetProvider = assetProvider;
        _gameProgressService = gameProgressService;
    }

    public PlantStaticData GetPlantConfig(PlantType plantType) =>
        _plants[plantType];

    public InteractionButtonStaticData GetInteractionButtonConfig(InteractionButtonType type) =>
        _interactionButtons[type];
    
    public async UniTask LoadStaticData()
    {
        GameConfig = await _assetProvider.Load<GameConfig>(StaticDataPath.GameConfigPath);
        
        _plants = await LoadDictionary<PlantStaticData, PlantType>(
            StaticDataPath.PlantConfigLabel, x => x.PlantType);
        
        _interactionButtons = await LoadDictionary<InteractionButtonStaticData, InteractionButtonType>(
            StaticDataPath.ButtonsConfigLabel, x => x.ButtonType);
    }
    
    private async UniTask<Dictionary<TKey, TData>> LoadDictionary<TData, TKey>(
        string label, System.Func<TData, TKey> keySelector) where TData : class
    {
        var list = await _assetProvider.LoadAssetList<TData>(label);
        return list.ToDictionary(keySelector, x => x);
    }
}