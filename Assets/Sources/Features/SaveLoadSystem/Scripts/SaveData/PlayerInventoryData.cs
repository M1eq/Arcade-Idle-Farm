using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public sealed class PlayerInventoryData
{
    [field: SerializeField] public List<PlayerInventoryItemData> ItemsDataList { get; private set; }

    public PlayerInventoryData(List<PlayerInventoryItemData> itemsDataList) => 
        ItemsDataList = itemsDataList;

    public PlayerInventoryData Clone()
    {
        var clonedItemsList = ItemsDataList
            .Select(item => new PlayerInventoryItemData(item.PlantType, item.Amount))
            .ToList();
        
        return new PlayerInventoryData(clonedItemsList);
    }
}