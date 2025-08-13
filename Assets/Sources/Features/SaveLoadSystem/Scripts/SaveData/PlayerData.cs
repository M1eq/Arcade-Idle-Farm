using System;

[Serializable]
public sealed class PlayerData : ISaveData
{
    //Написать InventoryData и сохранять инвентарь

    public bool EqualsData(PlayerData data) =>
        true;

    public PlayerData Clone() =>
        new();
}