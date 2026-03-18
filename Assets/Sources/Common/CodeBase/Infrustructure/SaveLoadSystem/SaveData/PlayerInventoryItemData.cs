using System;
using UnityEngine;

[Serializable]
public sealed class PlayerInventoryItemData
{
    [field: SerializeField] public PlantType PlantType { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }

    public PlayerInventoryItemData(PlantType plantType, int amount)
    {
        PlantType = plantType;
        Amount = amount;
    }
    
    public void SetAmount(int amount) => 
        Amount = amount;
    
    public override int GetHashCode() => 
        HashCode.Combine(PlantType, Amount);
    
    public override bool Equals(object obj)
    {
        return obj is PlayerInventoryItemData other &&
               PlantType == other.PlantType &&
               Amount == other.Amount;
    }
}