using UnityEngine;
using Zenject;

public class Sell : ISellService
{
    private IInventory _inventory;
    private IWallet _wallet;
    private IStaticDataService _staticData;

    [Inject]
    public void Construct(IInventory inventory, IWallet wallet, IStaticDataService staticData)
    {
        _wallet = wallet;
        _inventory = inventory;
        _staticData = staticData;
    }
    
    public void SellPlants(float sellMultiplier)
    {
        int plantToSell = (int)(Time.deltaTime * sellMultiplier);
        var inventoryItemsDictionary = _inventory.GetItemsDictionary();

        foreach (var item in inventoryItemsDictionary)
        {
            IReadOnlyInventoryItem inventoryItem = item.Value;
            int sellPrice = _staticData.GetPlantConfig(inventoryItem.Type).SellPrice;
            
            if (inventoryItem.Amount > 0)
            {
                if (plantToSell > inventoryItem.Amount)
                    plantToSell = inventoryItem.Amount;
                
                _inventory.Remove(inventoryItem.Type, plantToSell);
                _wallet.AddCoins(plantToSell * sellPrice);
            }
        }
    }
}