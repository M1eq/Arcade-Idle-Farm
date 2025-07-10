using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PlantFactory : IPlantFactory
{
    private readonly IStaticDataService _staticDataService;
    private readonly IAssetProvider _assetProvider;
    private readonly IInstantiator _instantiator;

    [Inject]
    public PlantFactory(IStaticDataService staticDataService, IAssetProvider assetProvider, IInstantiator instantiator)
    {
        _assetProvider = assetProvider;
        _staticDataService = staticDataService;
        _instantiator = instantiator;
    }
    
    public async UniTask<Plant> Create(PlantType plantType, Transform parent)
    {
        PlantStaticData config = _staticDataService.GetPlantConfig(plantType);
        GameObject prefab = await _assetProvider.Load<GameObject>(config.Prefab);

        Plant plant = _instantiator.InstantiatePrefabForComponent<Plant>(prefab, parent);
        plant.Initialize(config.ScaleConfig);
        
        plant.transform.parent = parent;
        plant.transform.rotation = Quaternion.identity;
        plant.transform.localPosition = Vector3.zero;
        plant.transform.localScale = Vector3.zero;
        
        return plant;
    }
}