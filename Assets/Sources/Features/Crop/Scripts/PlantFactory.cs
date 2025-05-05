using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PlantFactory : IPlantFactory
{
    private readonly IStaticDataService _staticDataService;
    private readonly IAssetProvider _assetProvider;

    [Inject]
    public PlantFactory(IStaticDataService staticDataService, IAssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
        _staticDataService = staticDataService;
    }
    
    public async UniTask<GameObject> Create(PlantType plantType, Transform parent)
    {
        PlantStaticData config = _staticDataService.GetPlantConfig(plantType);
        GameObject prefab = await _assetProvider.Load<GameObject>(config.Prefab);

        var plant = Object.Instantiate(prefab, parent);
        
        plant.transform.parent = parent;
        plant.transform.rotation = Quaternion.identity;
        plant.transform.localPosition = Vector3.zero;
        plant.transform.localScale = config.SeedScale;
        
        return plant;
    }
}