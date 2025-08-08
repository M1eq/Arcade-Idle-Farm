public class SaveDataFactory : ISaveDataFactory
{
    private readonly NewWalletDataConfig _newWalletDataConfig;

    public SaveDataFactory(IStaticDataService staticDataService)
    {
        _newWalletDataConfig = staticDataService.GetGameConfig().NewProgressConfig.NewWalletDataConfig;
    }

    public PlayerData CreateNewPlayerData() =>
        new();

    public WorldData CreateNewWorldData() =>
        new();

    public WalletData CreateNewWalletData() =>
        new(_newWalletDataConfig.Coins);
}