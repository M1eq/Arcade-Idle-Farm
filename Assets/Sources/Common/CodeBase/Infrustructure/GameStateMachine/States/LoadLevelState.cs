using Cysharp.Threading.Tasks;

public class LoadLevelState : IPayloadedState<string>
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IHudFactory _hudFactory;
    private readonly IGameFactory _gameFactory;
    private readonly IGameProgressService _gameProgressService;
    private readonly ISessionInfo _sessionInfo;

    public LoadLevelState(IGameStateMachine gameStateMachine, IHudFactory hudFactory,
        IGameFactory gameFactory, SceneLoader sceneLoader, IGameProgressService gameProgressService,
        ISessionInfo sessionInfo)
    {
        _sessionInfo = sessionInfo;
        _gameProgressService = gameProgressService;
        _hudFactory = hudFactory;
        _gameFactory = gameFactory;
        _sceneLoader = sceneLoader;
        _gameStateMachine = gameStateMachine;
    }

    public void Enter(string sceneName) =>
        _sceneLoader.LoadScene(sceneName, OnLevelSceneLoaded);

    public void Exit()
    {
    }

    private void OnLevelSceneLoaded() =>
        ConstructLevel().Forget();

    private async UniTask ConstructLevel()
    {
        _gameFactory.CreateGameRoot();
        await _hudFactory.CreateHudRoot();

        await UniTask.WhenAll(
            CreateLevelPrefab(),
            _gameFactory.CreatePlayer(),
            _hudFactory.CreateInventoryHud(),
            _hudFactory.CreateWalletHud(),
            _hudFactory.CreateJoystick()
        );

        _gameStateMachine.Enter<GameLoopState>();
    }

    private async UniTask CreateLevelPrefab()
    {
        WorldData worldData = _gameProgressService.Progress.WorldData;
        LevelType lastSavedLevelType = worldData.LastSavedLevelType;

        Level level = await _gameFactory.CreateLevel(lastSavedLevelType);

        if (worldData.TryGetLevelDataFor(lastSavedLevelType, out LevelData levelData))
            level.RestoreLevelBy(levelData);
        
        _sessionInfo.UpdateInfo(level);
    }
}