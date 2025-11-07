using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public interface IAssetProvider
{
    UniTask Initialize();
    void CleanUp();
    UniTask<GameObject> Instantiate(string path, Vector3 at);
    UniTask<GameObject> Instantiate(string path);
    UniTask<T> Load<T>(string address) where T : class;
    UniTask<T> Load<T>(AssetReference dataPrefabReference) where T : class;
    UniTask<List<T>> LoadAssetList<T>(string label) where T : class;
}
