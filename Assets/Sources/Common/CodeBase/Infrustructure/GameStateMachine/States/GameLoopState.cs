public class GameLoopState : IState
{
    private readonly IInputService _inputService;

    public GameLoopState(IInputService inputService)
    {
        _inputService = inputService;
    }
    
    public void Enter() => 
        _inputService.UnblockInput();
    
    public void Exit() { }
}
