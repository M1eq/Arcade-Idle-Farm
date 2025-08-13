using System;

[Serializable]
public sealed class WorldData : ISaveData
{
    public bool EqualsData(WorldData data) => 
        true;

    public WorldData Clone() => 
        new();
}