using System;
using UnityEngine;

[Serializable]
public class ItemIconData
{
    [field: SerializeField] public PlantType PlantType { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}