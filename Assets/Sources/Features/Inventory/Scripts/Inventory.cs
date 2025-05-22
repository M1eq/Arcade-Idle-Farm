using UnityEngine.Events;

public class Inventory : IInventory
{
    public event UnityAction<int> CornAmountChanged;
    
    private int _cornAmount;
    
    public void AddCorn(int amount)
    {
        if (amount <= 0)
            return;
        
        _cornAmount += amount;
        CornAmountChanged?.Invoke(_cornAmount);
    }
}