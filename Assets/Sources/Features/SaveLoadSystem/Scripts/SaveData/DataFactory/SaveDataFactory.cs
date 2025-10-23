public class SaveDataFactory : ISaveDataFactory
{
    private readonly NewWalletDataConfig _newWalletDataConfig;
    private readonly NewPlayerDataConfig _newPlayerDataConfig;

    public SaveDataFactory(IStaticDataService staticDataService)
    {
        _newWalletDataConfig = staticDataService.GetGameConfig().NewProgressConfig.NewWalletDataConfig;
        _newPlayerDataConfig = staticDataService.GetGameConfig().NewProgressConfig.NewPlayerDataConfig;
    }

    public PlayerData CreateNewPlayerData() =>
        new(_newPlayerDataConfig.InventoryData.Clone());

    public WorldData CreateNewWorldData() =>
        new();

    public WalletData CreateNewWalletData() =>
        new(_newWalletDataConfig.Coins);
}