using Cysharp.Threading.Tasks;

public class LoadLevelState : IPayloadedState<string>
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IHudFactory _hudFactory;
    private readonly IGameFactory _gameFactory;
    private readonly IGameProgressService _gameProgressService;

    public LoadLevelState(IGameStateMachine gameStateMachine, IHudFactory hudFactory,
        IGameFactory gameFactory, SceneLoader sceneLoader, IGameProgressService gameProgressService)
    {
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

        var walletHudTask = _hudFactory.CreateWalletHud();
        var inventoryHudTask = _hudFactory.CreateInventoryHud();

        await UniTask.WhenAll(
            _gameFactory.CreateLevel(),
            _gameFactory.CreatePlayer(),
            _hudFactory.CreateJoystick()
        );

        var walletHudHolder = await walletHudTask;
        await inventoryHudTask;

        await UniTask.WaitUntil(() => walletHudHolder.WalletHudUpdater.UpdatesSubscribed);
        await UniTask.WaitForEndOfFrame();
        
        _gameProgressService.ApplyProgress();
        _gameStateMachine.Enter<GameLoopState>();
    }
}