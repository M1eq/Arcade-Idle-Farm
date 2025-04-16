public interface IInputService
{
    bool InputBlocked { get; }
    void BlockInput();
    void UnblockInput();
}
