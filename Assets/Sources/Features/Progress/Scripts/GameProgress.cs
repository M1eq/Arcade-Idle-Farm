public sealed class GameProgress : ICloneable<GameProgress>
{
    public PlayerData PlayerData;
    public WorldData WorldData;

    public GameProgress(PlayerData playerData, WorldData worldData)
    {
        PlayerData = playerData;
        WorldData = worldData;
    }

    public GameProgress Clone() => 
        new(PlayerData.Clone(), WorldData.Clone());
}