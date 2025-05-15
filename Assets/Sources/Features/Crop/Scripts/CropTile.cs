using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class CropTile : MonoBehaviour
{
    public event UnityAction<CropTile> Sowed; 
    public event UnityAction<CropTile> Watered; 
    
    public bool Empty { get; private set; } = true;
    
    private IPlantFactory _iPlantFactory;
    private PlantType _plantType;
    private Plant _plant;

    [Inject]
    public void Construct(IPlantFactory iPlantFactory)
    {
        _iPlantFactory = iPlantFactory;
    }

    public void Initialize(PlantType plantType) => 
        _plantType = plantType;

    public async UniTask Sow()
    {
        Empty = false;
        
        _plant = await _iPlantFactory.Create(_plantType, transform);
        _plant.ScaleToSeed();
        
        Sowed?.Invoke(this);
    }

    public void Pour()
    {
        _plant.ScaleToWatered();
        Watered?.Invoke(this);
    }
}