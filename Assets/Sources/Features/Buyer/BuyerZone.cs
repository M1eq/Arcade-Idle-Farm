using UnityEngine;
using Zenject;

public class BuyerZone : MonoBehaviour
{
    private const float MultiplierStep = 300;
    
    private IInventory _inventory;
    private float _sellMultiplier;
    private bool _canSellPlants;

    [Inject]
    public void Construct(IInventory inventory)
    {
        _inventory = inventory;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            _canSellPlants = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_canSellPlants)
            SellPlants();
    }

    private void OnTriggerExit(Collider other) =>
        Reset();

    private void Reset()
    {
        _canSellPlants = false;
        _sellMultiplier = 0;
    }

    private void SellPlants()
    {
        _sellMultiplier += Time.deltaTime * MultiplierStep;

        int cornToSell = (int)(Time.deltaTime * _sellMultiplier);

        if (cornToSell > _inventory.CornAmount)
            cornToSell = _inventory.CornAmount;

        _inventory.ReduceCorn(cornToSell);
    }
}