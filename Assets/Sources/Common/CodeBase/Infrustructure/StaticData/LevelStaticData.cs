using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "LevelStaticData", menuName = "StaticData/LevelStaticData")]
public class LevelStaticData : ScriptableObject
{
    [field: SerializeField] public LevelType LevelType { get; private set; }
    [field: SerializeField] public AssetReference PrefabReference { get; private set; }
}