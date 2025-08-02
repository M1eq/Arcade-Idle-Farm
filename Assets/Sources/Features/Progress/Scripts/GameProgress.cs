public sealed class GameProgress
{
    public PlayerData PlayerData { get; }
    public WorldData WorldData { get; }
    public WalletData WalletData { get; }

    public GameProgress(PlayerData playerData, WorldData worldData, WalletData walletData)
    {
        PlayerData = playerData;
        WorldData = worldData;
        WalletData = walletData;
    }

    public GameProgress Clone() =>
        new(PlayerData.Clone(), WorldData.Clone(), WalletData.Clone());
}