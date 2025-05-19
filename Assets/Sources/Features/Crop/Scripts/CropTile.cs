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
    private PlantType _plantType;
    private Plant _plant;
    private CropTileConfig _config;

    [Inject]
    public void Construct(IPlantFactory iPlantFactory, IColorChanger colorChanger)
    {
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
        IsWatered = true;

        _plant.ScaleToWatered();
        _colorChanger.ChangeColorFor(_mesh, _config.WateredColor, _config.ColorChangeDuration);

        Watered?.Invoke(this);
    }

    public void Harvest()
    {
        Destroy(_plant.gameObject);
        _colorChanger.ChangeColorFor(_mesh, _config.DefaultColor, _config.ColorChangeDuration);

        IsEmpty = true;
        IsWatered = false;

        Harvested?.Invoke(this);
    }
}