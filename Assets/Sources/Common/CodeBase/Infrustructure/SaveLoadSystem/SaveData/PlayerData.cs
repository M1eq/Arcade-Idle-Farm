using System;
using System.Linq;
using UnityEngine;

[Serializable]
public sealed class PlayerData : ISaveData
{
    public PlayerInventoryData InventoryData => _playerInventoryData;
    
    [SerializeField] private PlayerInventoryData _playerInventoryData;

    public PlayerData(PlayerInventoryData playerInventoryData)
    {
        _playerInventoryData = playerInventoryData;
    }
    
    public bool EqualsData(PlayerData data) =>
        _playerInventoryData.ItemsDataList.SequenceEqual(data._playerInventoryData.ItemsDataList);

    public PlayerData Clone() => 
        new(_playerInventoryData.Clone());

    public void UpdateInventoryData(IInventory inventory) => 
        UpdateInventoryItemsData(inventory);

    private void UpdateInventoryItemsData(IInventory inventory)
    {
        var itemsDictionary = inventory.GetItemsDictionary();
    
        var savedItemsDictionary = _playerInventoryData.ItemsDataList
            .ToDictionary(item => item.PlantType, item => item);

        foreach (var dictionaryItem in itemsDictionary)
        {
            IReadOnlyInventoryItem inventoryItem = dictionaryItem.Value;
        
            if (savedItemsDictionary.TryGetValue(inventoryItem.Type, out var existingItem))
            {
                existingItem.SetAmount(inventoryItem.Amount);
            }
            else
            {
                PlayerInventoryItemData playerInventoryItemData = new(inventoryItem.Type, inventoryItem.Amount);
                _playerInventoryData.ItemsDataList.Add(playerInventoryItemData);
            }
        }
    }
}