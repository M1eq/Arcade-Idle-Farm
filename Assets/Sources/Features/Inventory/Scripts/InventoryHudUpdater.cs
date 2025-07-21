using Cysharp.Threading.Tasks;
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
    
    private void OnItemChanged(IReadOnlyInventoryItem changedItem) => 
        _inventoryHud.Set(changedItem.Type, changedItem.Amount).Forget();
    
    private void SubscribeUpdates() => 
        _inventory.ItemChanged += OnItemChanged;

    private void CleanUp() => 
        _inventory.ItemChanged -= OnItemChanged;
}