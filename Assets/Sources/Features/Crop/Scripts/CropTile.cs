using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class CropTile : MonoBehaviour
{
    public bool Empty { get; private set; } = true;

    [SerializeField] private PlantType _plantType;

    private IPlantFactory _iPlantFactory;

    [Inject]
    public void Construct(IPlantFactory iPlantFactory)
    {
        _iPlantFactory = iPlantFactory;
    }

    public void Sow()
    {
        Empty = false;
        _iPlantFactory.Create(_plantType, transform).Forget();
    }
}