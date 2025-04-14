using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public interface IAssetProvider
{
    UniTask<GameObject> Instantiate(string path, Vector3 at);
    UniTask<GameObject> Instantiate(string path);
    UniTask<T> Load<T>(AssetReference dataPrefabReference) where T : class;
    void Cleanup();
    UniTask<T> Load<T>(string address) where T : class;
    void Initialize();
}
