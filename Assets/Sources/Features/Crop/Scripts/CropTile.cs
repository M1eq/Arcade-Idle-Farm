using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Random = UnityEngine.Random;

public class CropTile : MonoBehaviour
{
    public event UnityAction<CropTile> Sowed;
    public event UnityAction<CropTile> Watered;
    public event UnityAction<CropTile> Harvested;

    public CropTileState CropTileState { get; private set; } = CropTileState.Empty;
    public string ID => _uniqueID.Id;

    [SerializeField] private UniqueID _uniqueID;
    [SerializeField] private MeshRenderer _mesh;

    private IStaticDataService _staticData;
    private IPlantFactory _iPlantFactory;
    private IColorChanger _colorChanger;
    private ICollector _collector;
    private PlantType _plantType;
    private Plant _plant;
    private CropTileConfig _config;

    [Inject]
    public void Construct(IPlantFactory iPlantFactory, IColorChanger colorChanger,
        ICollector collector, IStaticDataService staticData)
    {
        _collector = collector;
        _staticData = staticData;
        _colorChanger = colorChanger;
        _iPlantFactory = iPlantFactory;
    }

    public void Initialize(PlantType plantType, CropTileConfig config)
    {
        _plantType = plantType;
        _config = config;
    }

    public void RestoreBy(CropTileData cropTileData)
    {
        switch (cropTileData.CropTileState)
        {
            case CropTileState.Sowed:
                Sow().Forget();
                break;
            
            case CropTileState.Watered:
                Water();
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public async UniTask Sow()
    {
        CropTileState = CropTileState.Sowed;

        _plant = await _iPlantFactory.Create(_plantType, transform);
        _plant.ScaleToSeed();

        Sowed?.Invoke(this);
    }

    public void Water()
    {
        CropTileState = CropTileState.Watered;

        _plant.ScaleToWatered();
        _colorChanger.ChangeColorFor(_mesh, _config.WateredColor, _config.WateredDuration);

        Watered?.Invoke(this);
    }

    public void Harvest()
    {
        PlantStaticData plantData = _staticData.GetPlantConfig(_plantType);
        Destroy(_plant.gameObject);

        _collector.Collect(transform, plantData.CollectableType,
            Random.Range(plantData.LootAmounts.x, plantData.LootAmounts.y + 1));

        _colorChanger.ChangeColorFor(_mesh, _config.DefaultColor,
            _config.RestoreDefaultDurations[Random.Range(0, _config.RestoreDefaultDurations.Length)]);

        CropTileState = CropTileState.Empty;

        Harvested?.Invoke(this);
    }
}