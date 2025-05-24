using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class PlantsSellZone : MonoBehaviour
{
    [SerializeField] private TriggerObserver _sellZoneObserver;

    private bool _canSellPlants;
    private float _sellMultiplier;
    private ISellService _sellService;
    private PlantsSellZoneConfig _config;

    [Inject]
    public void Construct(ISellService sellService)
    {
        _sellService = sellService;
    }

    public void Initialize(PlantsSellZoneConfig config) => 
        _config = config;

    private void Start() =>
        SubscribeUpdates();

    private void OnDestroy() =>
        CleanUp();

    private void ObservedTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            _canSellPlants = true;
    }

    private void ObservedTriggerStay(Collider other)
    {
        if (_canSellPlants)
            SellPlants();
    }

    private void ObservedTriggerExit(Collider other) =>
        Reset();
    
    private void Reset()
    {
        _canSellPlants = false;
        _sellMultiplier = 0;
    }

    private void SellPlants()
    {
        _sellMultiplier += Time.deltaTime * _config.SellMultiplierStep;
        _sellService.SellPlants(_sellMultiplier);
    }
    
    private void SubscribeUpdates()
    {
        _sellZoneObserver.TriggerEnter += ObservedTriggerEnter;
        _sellZoneObserver.TriggerStay += ObservedTriggerStay;
        _sellZoneObserver.TriggerExit += ObservedTriggerExit;
    }

    private void CleanUp()
    {
        _sellZoneObserver.TriggerEnter -= ObservedTriggerEnter;
        _sellZoneObserver.TriggerStay -= ObservedTriggerStay;
        _sellZoneObserver.TriggerExit -= ObservedTriggerExit;
    }
}