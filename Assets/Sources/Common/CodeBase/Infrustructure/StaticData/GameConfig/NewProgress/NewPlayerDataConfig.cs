using System;
using UnityEngine;

[Serializable]
public class NewPlayerDataConfig
{
    [field: SerializeField] public PlayerInventoryData InventoryData { get; private set; }
}