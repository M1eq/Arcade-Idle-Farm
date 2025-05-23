using UnityEngine.Events;

public interface IInventory
{
    event UnityAction<int> CornAmountChanged;
    int CornAmount { get; }
    void AddCorn(int amount);
    void ReduceCorn(int amount);
}