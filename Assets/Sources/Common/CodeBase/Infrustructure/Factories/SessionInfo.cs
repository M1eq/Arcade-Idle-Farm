public class SessionInfo : ISessionInfo
{
    public Level Level { get; private set; }

    public void UpdateInfo(Level level) => 
        Level = level;
}