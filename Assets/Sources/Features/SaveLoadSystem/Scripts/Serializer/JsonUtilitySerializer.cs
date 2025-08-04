using Cysharp.Threading.Tasks;
using UnityEngine;

public sealed class JsonUtilitySerializer : ISerializer
{
    public UniTask<string> SerializeAsync<TData>(TData data)
    {
        string json = JsonUtility.ToJson(data);
        return UniTask.FromResult(json);
    }

    public UniTask<TData> DeserializeAsync<TData>(string json)
    {
        var data = JsonUtility.FromJson<TData>(json);
        return UniTask.FromResult(data);
    }
}