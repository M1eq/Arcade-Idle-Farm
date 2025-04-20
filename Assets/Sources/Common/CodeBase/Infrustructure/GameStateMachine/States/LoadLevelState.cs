using Cysharp.Threading.Tasks;

public class LoadLevelState : IPayloadedState<string>
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IHudFactory _hudFactory;

    public LoadLevelState(IGameStateMachine gameStateMachine, IHudFactory hudFactory, SceneLoader sceneLoader)
    {
        _hudFactory = hudFactory;
        _sceneLoader = sceneLoader;
        _gameStateMachine = gameStateMachine;
    }

    public void Enter(string sceneName) =>
        _sceneLoader.LoadScene(sceneName, OnLevelLoaded);

    public void Exit() { }

    private void OnLevelLoaded()
    {
        CreateHud().Forget();
        _gameStateMachine.Enter<GameLoopState>();
    }

    private async UniTask CreateHud()
    {
        await _hudFactory.CreateHudRoot();
        await _hudFactory.CreateJoystick();
    }
}