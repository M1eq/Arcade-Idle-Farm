using System;

[Serializable]
public sealed class WorldData : ISaveData<WorldData>, ICloneable<WorldData>
{
    public int Version { get; }
    public string Timestamp { get; }

    public WorldData(int version, string timestamp)
    {
        Version = version;
        Timestamp = timestamp;
    }
    
    public bool EqualsData(WorldData data)
    {
        throw new NotImplementedException();
    }

    public WorldData Clone() => 
        new(Version, Timestamp);
}