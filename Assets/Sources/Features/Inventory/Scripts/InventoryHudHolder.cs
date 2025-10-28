using UnityEngine;

public class InventoryHudHolder : MonoBehaviour
{
    [field: SerializeField] public InventoryHud InventoryHud { get; private set; }
    [field: SerializeField] public InventoryHudUpdater InventoryHudUpdater { get; private set; }
}