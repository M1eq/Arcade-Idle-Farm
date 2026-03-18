using System;
using System.Collections.Generic;

public static class SaveDataKeys
{
    private static readonly Dictionary<Type, string> DataKeys = new()
    {
        { typeof(PlayerData), "PlayerData" },
        { typeof(WorldData), "WorldData" },
        { typeof(WalletData), "WalletData" }
    };
    
    public static string GetKey<TData>() where TData : ISaveData
    {
        Type dataType = typeof(TData);
    
        if (DataKeys.TryGetValue(dataType, out string key))
            return key;

        throw new KeyNotFoundException($"Key for save data of type {dataType} not found");
    }
}