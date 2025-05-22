using UnityEngine.Events;

public interface IInventory
{
    event UnityAction<int> CornAmountChanged;
    void AddCorn(int amount);
}