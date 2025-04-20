using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private const string GameConfigPath = "StaticData/GameConfig";

    public GameConfig GetGameConfig() => 
        Resources.Load<GameConfig>(GameConfigPath);
}