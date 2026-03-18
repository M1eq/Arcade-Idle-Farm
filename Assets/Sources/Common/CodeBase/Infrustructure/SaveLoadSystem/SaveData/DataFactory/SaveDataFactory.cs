using System.Collections.Generic;

public class SaveDataFactory : ISaveDataFactory
{
    private readonly IStaticDataService _staticDataService;

    public SaveDataFactory(IStaticDataService staticDataService)
    {
        _staticDataService = staticDataService;
    }
    
    public PlayerData CreateNewPlayerData()
    {
        var newPlayerDataConfig = _staticDataService.GameConfig.NewProgressConfig.NewPlayerDataConfig;
        return new PlayerData(newPlayerDataConfig.InventoryData.Clone());
    }

    public WorldData CreateNewWorldData()
    {
        var newWorldDataConfig = _staticDataService.GameConfig.NewProgressConfig.NewWorldDataConfig;
        return new WorldData(new List<LevelDataContainer>(), newWorldDataConfig.StartLevelType);
    }

    public WalletData CreateNewWalletData()
    {
        var newWalletDataConfig = _staticDataService.GameConfig.NewProgressConfig.NewWalletDataConfig;
        return new WalletData(newWalletDataConfig.Coins);
    }
}