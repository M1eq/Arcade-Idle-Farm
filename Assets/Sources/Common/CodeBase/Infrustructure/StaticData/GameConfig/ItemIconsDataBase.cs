using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ItemIconsDataBase
{
    [SerializeField] private List<ItemIconData> _itemIcons;

    public Sprite GetIcon(PlantType type)
    {
        var itemIconData = _itemIcons
            .Select(x => x)
            .FirstOrDefault(x => x.PlantType == type);

        return itemIconData.Icon;
    }
}