using System;

[Serializable]
public sealed class PlayerData : ISaveData<PlayerData>, ICloneable<PlayerData>
{
    public int Version { get; }
    public string Timestamp { get; }

    public PlayerData(int version, string timestamp)
    {
        Version = version;
        Timestamp = timestamp;
    }

    public bool EqualsData(PlayerData data)
    {
        throw new NotImplementedException();
    }

    public PlayerData Clone() => 
        new(Version, Timestamp);
}