public interface ISessionInfo
{
    Level Level { get; }
    void UpdateInfo(Level level);
}