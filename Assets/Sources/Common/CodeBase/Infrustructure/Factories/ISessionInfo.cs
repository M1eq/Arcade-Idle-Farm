public interface ISessionInfo
{
    Level CurrentLevel { get; }
    void UpdateInfo(Level level);
}