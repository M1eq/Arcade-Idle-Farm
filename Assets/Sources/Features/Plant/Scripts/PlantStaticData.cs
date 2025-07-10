using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "PlantStaticData", menuName = "StaticData/PlantStaticData")]
public class PlantStaticData : ScriptableObject
{
    [field: SerializeField] public PlantType PlantType { get; private set; }
    [field: SerializeField] public AssetReference Prefab { get; private set; }
    [field: SerializeField] public PlantScaleConfig ScaleConfig { get; private set; }
}