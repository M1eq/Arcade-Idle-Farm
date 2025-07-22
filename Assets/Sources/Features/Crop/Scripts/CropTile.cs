using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class CropTile : MonoBehaviour
{
    public event UnityAction<CropTile> Sowed;
    public event UnityAction<CropTile> Watered;
    public event UnityAction<CropTile> Harvested;

    public bool IsEmpty { get; private set; } = true;
    public bool IsWatered { get; private set; }

    [SerializeField] private MeshRenderer _mesh;

    private IPlantFactory _iPlantFactory;
    private IColorChanger _colorChanger;
    private ICollector _collector;
    private PlantType _plantType;
    private Plant _plant;
    private CropTileConfig _config;

    [Inject]
    public void Construct(IPlantFactory iPlantFactory, IColorChanger colorChanger, ICollector collector)
    {
        _collector = collector;
        _colorChanger = colorChanger;
        _iPlantFactory = iPlantFactory;
    }

    public void Initialize(PlantType plantType, CropTileConfig config)
    {
        _plantType = plantType;
        _config = config;
    }

    public async UniTask Sow()
    {
        IsEmpty = false;

        _plant = await _iPlantFactory.Create(_plantType, transform);
        _plant.ScaleToSeed();

        Sowed?.Invoke(this);
    }

    public void Water()
    {
        if (_plant == null)
            return;
        
        IsWatered = true;
        
        _plant.ScaleToWatered();
        _colorChanger.ChangeColorFor(_mesh, _config.WateredColor, _config.WateredDuration);

        Watered?.Invoke(this);
    }

    public void Harvest()
    {
        if (_plant == null)
            return;
        
        Destroy(_plant.gameObject);
        _collector.Collect(transform, CollectableType.Corn, 1);
        
        _colorChanger.ChangeColorFor(_mesh, _config.DefaultColor,
            _config.RestoreDefaultDurations[Random.Range(0, _config.RestoreDefaultDurations.Length)]);

        IsEmpty = true;
        IsWatered = false;

        Harvested?.Invoke(this);
    }
}