public class InventoryItem : IReadOnlyInventoryItem
{
    public PlantType Type { get; }
    public int Amount { get; private set; }

    public InventoryItem(PlantType type, int amount)
    {
        Type = type;
        Amount = amount;
    }

    public void Add(int amount)
    {
        if (amount <= 0)
            return;
        
        Amount += amount;
    }

    public void Remove(int amount)
    {
        if (amount <= 0)
            return;
        
        if (Amount - amount < 0)
            Amount = 0;
        else
            Amount -= amount;
    }
}
