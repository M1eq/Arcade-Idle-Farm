using Cysharp.Threading.Tasks;

public sealed class GameProgressService : IGameProgressService
{
    public GameProgress Progress { get; private set; }

    private bool PlayerDataUpdated => _cachedProgress.PlayerData.EqualsData(Progress.PlayerData) == false;
    private bool WorldDataUpdated => _cachedProgress.WorldData.EqualsData(Progress.WorldData) == false;
    private bool WalletDataUpdated => _cachedProgress.WalletData.EqualsData(Progress.WalletData) == false;

    private GameProgress _cachedProgress;
    private readonly ISaveSystem _saveSystem;
    private readonly IGameFactory _gameFactory;
    private readonly NewWalletDataConfig _newWalletDataConfig;

    public GameProgressService(ISaveSystem saveSystem, IGameFactory gameFactory, IStaticDataService staticDataService)
    {
        _saveSystem = saveSystem;
        _gameFactory = gameFactory;
        
        _newWalletDataConfig = staticDataService.GetGameConfig().NewProgressConfig.NewWalletDataConfig;
    }

    public void ApplyProgress()
    {
        foreach (var progressReader in _gameFactory.ProgressReaders)
            progressReader.ApplyProgress(Progress);
    }

    public async UniTask SaveProgressAsync()
    {
        if (PlayerDataUpdated)
            await _saveSystem.SaveAsync(Progress.PlayerData);

        if (WorldDataUpdated)
            await _saveSystem.SaveAsync(Progress.WorldData);

        if (WalletDataUpdated)
            await _saveSystem.SaveAsync(Progress.WalletData);

        _cachedProgress = Progress.Clone();
    }

    public async UniTask LoadProgressAsync()
    {
        var playerData = await _saveSystem.LoadAsync<PlayerData>();
        var worldData = await _saveSystem.LoadAsync<WorldData>();
        var walletData = await _saveSystem.LoadAsync<WalletData>();

        Progress = new GameProgress(playerData, worldData, walletData);
        _cachedProgress = Progress.Clone();
    }

    public async UniTask<bool> SavedProgressExists()
    {
        var playerDataExists = await _saveSystem.ExistsAsync<PlayerData>();
        var worldDataExists = await _saveSystem.ExistsAsync<WorldData>();
        var walletDataExists = await _saveSystem.ExistsAsync<WalletData>();
        
        return playerDataExists && worldDataExists && walletDataExists;
    }

    public void InitializeNewProgress()
    {
        PlayerData playerData = GetNewPlayerData();
        WorldData worldData = GetNewWorldData();
        WalletData walletData = GetNewWalletData();
        
        Progress = new GameProgress(playerData, worldData, walletData);
        _cachedProgress = Progress.Clone();
    }
    
    private PlayerData GetNewPlayerData() => 
        new();

    private WorldData GetNewWorldData() => 
        new();

    private WalletData GetNewWalletData() =>
        new(_newWalletDataConfig.Coins);
}