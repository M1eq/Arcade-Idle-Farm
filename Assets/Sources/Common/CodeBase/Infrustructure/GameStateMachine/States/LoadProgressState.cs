public class LoadProgressState : IState
{
    private readonly IGameStateMachine _gameStateMachine;

    public LoadProgressState(IGameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }
    
    public void Enter() => 
        _gameStateMachine.Enter<LoadLevelState, string>(SceneNames.GAMELOOP_SCENE);
    
    public void Exit() { }
}