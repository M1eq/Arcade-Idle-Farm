public class LoadLevelState : IPayloadedState<string>
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;

    public LoadLevelState(IGameStateMachine gameStateMachine, SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        _gameStateMachine = gameStateMachine;
    }
    
    public void Enter(string stateName) => 
        _sceneLoader.LoadScene(stateName, OnLevelLoaded);

    public void Exit() { }
    
    private void OnLevelLoaded() => 
        _gameStateMachine.Enter<GameLoopState>();
}
