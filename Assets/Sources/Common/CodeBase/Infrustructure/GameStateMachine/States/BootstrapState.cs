public class BootstrapState : IState
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly IAssetProvider _assetProvider;
    private readonly SceneLoader _sceneLoader;
    private readonly IInputService _inputService;

    public BootstrapState(IGameStateMachine gameStateMachine, IAssetProvider assetProvider,
        SceneLoader sceneLoader, IInputService inputService)
    {
        _gameStateMachine = gameStateMachine;
        _assetProvider = assetProvider;
        _inputService = inputService;
        _sceneLoader = sceneLoader;
    }

    public void Enter() =>
        _sceneLoader.LoadScene(SceneNames.INITIAL_SCENE, OnInitialSceneLoaded);
    
    public void Exit() { }

    private void OnInitialSceneLoaded()
    {
        _assetProvider.Initialize();
        _inputService.BlockInput();
        
        _gameStateMachine.Enter<LoadProgressState>();
    }
}
