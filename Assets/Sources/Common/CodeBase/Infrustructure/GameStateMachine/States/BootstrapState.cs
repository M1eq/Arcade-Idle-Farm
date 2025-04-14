public class BootstrapState : IState
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly IAssetProvider _assetProvider;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(IGameStateMachine gameStateMachine, IAssetProvider assetProvider, SceneLoader sceneLoader)
    {
        _gameStateMachine = gameStateMachine;
        _assetProvider = assetProvider;
        _sceneLoader = sceneLoader;
    }

    public void Enter() =>
        _sceneLoader.LoadScene(SceneNames.INITIAL_SCENE, OnInitialSceneLoaded);
    
    public void Exit() { }

    private void OnInitialSceneLoaded()
    {
        _assetProvider.Initialize();
        _gameStateMachine.Enter<LoadProgressState>();
    }
}
