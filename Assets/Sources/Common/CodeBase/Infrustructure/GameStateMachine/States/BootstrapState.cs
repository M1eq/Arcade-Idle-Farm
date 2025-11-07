using Cysharp.Threading.Tasks;

public class BootstrapState : IState
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly IAssetProvider _assetProvider;
    private readonly SceneLoader _sceneLoader;
    private readonly IInputService _inputService;
    private readonly IStaticDataService _staticDataService;

    public BootstrapState(IGameStateMachine gameStateMachine, IAssetProvider assetProvider,
        SceneLoader sceneLoader, IInputService inputService, IStaticDataService staticDataService)
    {
        _staticDataService = staticDataService;
        _gameStateMachine = gameStateMachine;
        _assetProvider = assetProvider;
        _inputService = inputService;
        _sceneLoader = sceneLoader;
    }

    public void Enter() =>
        _sceneLoader.LoadScene(SceneNames.INITIAL_SCENE, OnInitialSceneLoaded);

    public void Exit()
    {
    }

    private void OnInitialSceneLoaded() =>
        Bootstrap().Forget();

    private async UniTask Bootstrap()
    {
        await _assetProvider.Initialize();
        await _staticDataService.LoadStaticData();
        
        _inputService.BlockInput();
        _gameStateMachine.Enter<LoadProgressState>();
    }
}