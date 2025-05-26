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
        
        var inventoryItemsDictionary = _inventory.GetItemsDictionary();

        foreach (var item in inventoryItemsDictionary)
        {
            IReadOnlyInventoryItem inventoryItem = item.Value;

            if (inventoryItem.Amount > 0)
            {
                if (plantToSell > inventoryItem.Amount)
                    plantToSell = inventoryItem.Amount;
                
                _inventory.Remove(inventoryItem.Type, plantToSell);
                _wallet.AddCoins(plantToSell);
            }
        }
    }
}