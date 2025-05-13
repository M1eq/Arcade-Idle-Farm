using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class CropTile : MonoBehaviour
{
    public event UnityAction<CropTile> Sowed; 
    
    public bool Empty { get; private set; } = true;
    
    private IPlantFactory _iPlantFactory;
    private PlantType _plantType;

    [Inject]
    public void Construct(IPlantFactory iPlantFactory)
    {
        _iPlantFactory = iPlantFactory;
    }

    public void Initialize(PlantType plantType) => 
        _plantType = plantType;

    public void Sow()
    {
        Empty = false;
        _iPlantFactory.Create(_plantType, transform).Forget();
        
        Sowed?.Invoke(this);
    }
}