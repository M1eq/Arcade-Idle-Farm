using Cysharp.Threading.Tasks;

public class LoadProgressState : IState
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly IGameProgressService _gameProgressService;

    public LoadProgressState(IGameStateMachine gameStateMachine, IGameProgressService gameProgressService)
    {
        _gameStateMachine = gameStateMachine;
        _gameProgressService = gameProgressService;
    }

    public void Enter() =>
        LoadProgressOrInitNew().Forget();

    public void Exit()
    {
    }

    private async UniTask LoadProgressOrInitNew()
    {
        bool saveExists = await _gameProgressService.SavedProgressExists();

        if (saveExists)
        {
            await _gameProgressService.LoadProgressAsync();
        }
        else
        {
            _gameProgressService.InitializeNewProgress();
            await _gameProgressService.SaveProgressAsync();
        }

        _gameStateMachine.Enter<LoadLevelState, string>(SceneNames.GAMELOOP_SCENE);
    }
}