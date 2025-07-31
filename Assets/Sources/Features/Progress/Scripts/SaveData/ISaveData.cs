public interface ISaveData
{
    int Version { get; }
    string Timestamp { get; }
}

public interface ISaveData<T> : ISaveData where T : ISaveData<T>
{
    bool EqualsData(T data);
}