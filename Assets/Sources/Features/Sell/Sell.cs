using UnityEngine;
using Zenject;

public class Sell : ISellService
{
    private IInventory _inventory;
    private IWallet _wallet;

    [Inject]
    public void Construct(IInventory inventory, IWallet wallet)
    {
        _wallet = wallet;
        _inventory = inventory;
    }
    
    public void SellPlants(float sellMultiplier)
    {
        int plantToSell = (int)(Time.deltaTime * sellMultiplier);

        if (plantToSell > _inventory.CornAmount)
            plantToSell = _inventory.CornAmount;

        _inventory.ReduceCorn(plantToSell);
        _wallet.AddCoins(plantToSell);
    }
}