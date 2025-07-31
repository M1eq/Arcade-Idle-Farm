using Cysharp.Threading.Tasks;

public sealed class GameProgressService : IGameProgressService
{
    public GameProgress Progress { get; private set; }
    private bool PlayerDataUpdated => _cachedProgress.PlayerData.EqualsData(Progress.PlayerData) == false;
    private bool WorldDataUpdated => _cachedProgress.WorldData.EqualsData(Progress.WorldData) == false;
    
    private GameProgress _cachedProgress;
    private readonly ISaveSystem _saveSystem;
    private readonly IGameFactory _gameFactory;

    public GameProgressService(ISaveSystem saveSystem, IGameFactory gameFactory)
    {
        _saveSystem = saveSystem;
        _gameFactory = gameFactory;
    }

    public UniTask ApplyProgressAsync()
    {
        throw new System.NotImplementedException();
    }

    public async UniTask UpdateProgressAsync()
    {
        if (PlayerDataUpdated)
            await _saveSystem.SaveAsync(Progress.PlayerData);

        if (WorldDataUpdated)
            await _saveSystem.SaveAsync(Progress.WorldData);

        _cachedProgress = Progress.Clone();
    }

    public async UniTask LoadProgressAsync()
    {
        var playerData = await _saveSystem.LoadAsync<PlayerData>();
        var worldData = await _saveSystem.LoadAsync<WorldData>();

        Progress = new GameProgress(playerData, worldData);
        _cachedProgress = Progress.Clone();
    }
}