using System;

[Serializable]
public sealed class WorldData : ISaveData
{
    public bool EqualsData(WorldData data)
    {
        throw new NotImplementedException();
    }

    public WorldData Clone() => 
        new();
}