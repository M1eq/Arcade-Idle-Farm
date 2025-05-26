using System.Collections.Generic;
using UnityEngine.Events;

public interface IInventory
{
    event UnityAction<IReadOnlyInventoryItem> ItemChanged;
    void Add(PlantType type, int amount);
    void Remove(PlantType type, int amount);
    public IReadOnlyDictionary<PlantType, IReadOnlyInventoryItem> GetItemsDictionary();
}