using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "PlantStaticData", menuName = "StaticData/PlantStaticData")]
public class PlantStaticData : ScriptableObject
{
    [field: SerializeField] public PlantType PlantType { get; private set; }
    [field: SerializeField] public CollectableType CollectableType { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public AssetReference Prefab { get; private set; }
    [field: Space(10), SerializeField] public int SellPrice { get; private set; }
    [field: SerializeField] public int[] LootAmounts { get; private set; }
    [field: Space(10), SerializeField] public PlantScaleConfig ScaleConfig { get; private set; }
}