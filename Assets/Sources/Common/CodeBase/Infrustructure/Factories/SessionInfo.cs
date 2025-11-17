public class SessionInfo : ISessionInfo
{
    public Level CurrentLevel { get; private set; }

    public void UpdateInfo(Level level) => 
        CurrentLevel = level;
}