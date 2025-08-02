using Cysharp.Threading.Tasks;

public interface ISaveSystem
{
    UniTask SaveAsync<TData>(TData data) where TData : ISaveData;
    UniTask<TData> LoadAsync<TData>() where TData : ISaveData;
    UniTask<bool> ExistsAsync<TData>() where TData : ISaveData;
}