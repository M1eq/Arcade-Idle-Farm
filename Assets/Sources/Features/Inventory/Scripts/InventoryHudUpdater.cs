using UnityEngine;
using Zenject;

public class InventoryHudUpdater : MonoBehaviour
{
    [SerializeField] private InventoryHud _inventoryHud;
    
    private IInventory _inventory;

    [Inject]
    public void Construct(IInventory inventory)
    {
        _inventory = inventory;
    }

    private void Start() => 
        SubscribeUpdates();

    private void OnDestroy() => 
        CleanUp();
    
    private void OnCornAmountChanged(int cornAmount) => 
        _inventoryHud.SetCornAmount(cornAmount);
    
    private void SubscribeUpdates() => 
        _inventory.CornAmountChanged += OnCornAmountChanged;

    private void CleanUp() => 
        _inventory.CornAmountChanged -= OnCornAmountChanged;
}