using UnityEngine.Events;

public class Inventory : IInventory
{
    public event UnityAction<int> CornAmountChanged;
    public int CornAmount { get; private set; }
    
    public void AddCorn(int amount)
    {
        if (amount <= 0)
            return;
        
        CornAmount += amount;
        CornAmountChanged?.Invoke(CornAmount);
    }

    public void ReduceCorn(int amount)
    {
        if (amount <= 0)
            return;
        
        CornAmount -= amount;
        CornAmountChanged?.Invoke(CornAmount);
    }
}