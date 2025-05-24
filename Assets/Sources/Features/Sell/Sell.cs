using UnityEngine;
using Zenject;

public class Sell : ISellService
{
    private IInventory _inventory;
    
    [Inject]
    public void Construct(IInventory inventory)
    {
        _inventory = inventory;
    }
    
    public void SellPlants(float sellMultiplier)
    {
        int cornToSell = (int)(Time.deltaTime * sellMultiplier);

        if (cornToSell > _inventory.CornAmount)
            cornToSell = _inventory.CornAmount;

        _inventory.ReduceCorn(cornToSell);
    }
}