using Cysharp.Threading.Tasks;

public sealed class SaveSystem : ISaveSystem
{
    public async UniTask SaveAsync<TData>(TData data) where TData : ISaveData
    {        
        // string dataKey = GetKey<TData>();  
        // string serializedData = await SerializeAsync(data);  
        // await WriteToDataStorageAsync(dataKey, serializedData);  
    }  

    public async UniTask<TData> LoadAsync<TData>() where TData : ISaveData
    {        
        // string dataKey = GetKey<TData>();  
        // string serializedData = await ReadFromDataStorageAsync(dataKey);  
        // return await DeserializeAsync<TData>(serializedData);  
    }
}