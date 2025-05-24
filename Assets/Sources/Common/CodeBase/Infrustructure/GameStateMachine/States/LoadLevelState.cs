using Cysharp.Threading.Tasks;

public class LoadLevelState : IPayloadedState<string>
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IHudFactory _hudFactory;
    private readonly IGameFactory _gameFactory;

    public LoadLevelState(IGameStateMachine gameStateMachine, IHudFactory hudFactory,
        IGameFactory gameFactory, SceneLoader sceneLoader)
    {
        _hudFactory = hudFactory;
        _gameFactory = gameFactory;
        _sceneLoader = sceneLoader;
        _gameStateMachine = gameStateMachine;
    }

    public void Enter(string sceneName) =>
        _sceneLoader.LoadScene(sceneName, OnLevelSceneLoaded);

    public void Exit() { }

    private void OnLevelSceneLoaded() => 
        ConstructLevel().Forget();

    private async UniTask ConstructLevel()
    {
        _gameFactory.CreateGameRoot();
        await _hudFactory.CreateHudRoot();

        await UniTask.WhenAll(
            _gameFactory.CreateLevel(),
            _gameFactory.CreatePlayer(),
            _hudFactory.CreateInventoryHud(),
            _hudFactory.CreateWalletHud(),
            _hudFactory.CreateJoystick());
        
        _gameStateMachine.Enter<GameLoopState>();
    }
}