using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class Inventory : IInventory
{
    public event UnityAction<IReadOnlyInventoryItem> ItemChanged;

    private readonly Dictionary<PlantType, InventoryItem> _items = new();

    public void Add(PlantType type, int amount)
    {
        if (amount <= 0)
            return;

        if (_items.TryGetValue(type, out var item))
            item.Add(amount);
        else
            _items.Add(type, new InventoryItem(type, amount));

        ItemChanged?.Invoke(_items[type]);
    }

    public void Remove(PlantType type, int amount)
    {
        if (amount <= 0)
            return;

        if (_items.TryGetValue(type, out var item))
            item.Remove(amount);

        ItemChanged?.Invoke(_items[type]);
    }

    public IReadOnlyDictionary<PlantType, IReadOnlyInventoryItem> GetItemsDictionary()
    {
        return _items.ToDictionary(pair => pair.Key,
            pair => (IReadOnlyInventoryItem)pair.Value);
    }
}