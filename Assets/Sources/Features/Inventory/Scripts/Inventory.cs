using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class Inventory : IInventory, IDisposable
{
    public event UnityAction<IReadOnlyInventoryItem> ItemChanged;

    private readonly Dictionary<PlantType, InventoryItem> _items = new();
    private readonly IGameProgressService _gameProgressService;

    public Inventory(IGameProgressService gameProgressService)
    {
        _gameProgressService = gameProgressService;
        _gameProgressService.ProgressLoaded += OnProgressLoaded;
    }
    
    public void Add(PlantType type, int amount)
    {
        if (amount <= 0)
            return;

        if (_items.TryGetValue(type, out var item))
            item.Add(amount);
        else
            _items.Add(type, new InventoryItem(type, amount));

        InvokeItemChange(type);
    }

    public void Remove(PlantType type, int amount)
    {
        if (amount <= 0)
            return;

        if (_items.TryGetValue(type, out var item))
            item.Remove(amount);

        InvokeItemChange(type);
    }
    
    public IReadOnlyDictionary<PlantType, IReadOnlyInventoryItem> GetItemsDictionary()
    {
        return _items.ToDictionary(pair => pair.Key,
            pair => (IReadOnlyInventoryItem)pair.Value);
    }

    public void Dispose() => 
        _gameProgressService.ProgressLoaded -= OnProgressLoaded;

    private void OnProgressLoaded() => 
        ApplyProgress();

    private void InvokeItemChange(PlantType type)
    {
        _gameProgressService.Progress.PlayerData.UpdateInventoryData(this);
        ItemChanged?.Invoke(_items[type]);
    }
    
    private void ApplyProgress()
    {
        _items.Clear();
        var inventoryData = _gameProgressService.Progress.PlayerData.InventoryData;

        if (inventoryData.ItemsDataList.Count > 0)
        {
            foreach (var itemData in inventoryData.ItemsDataList)
            {
                if (itemData.Amount > 0) 
                    _items[itemData.PlantType] = new InventoryItem(itemData.PlantType, itemData.Amount);
            }
        }
    }
}