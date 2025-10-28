using UnityEngine;

public class WalletHudHolder : MonoBehaviour
{
    [field: SerializeField] public WalletHud WalletHud { get; private set; }
    [field: SerializeField] public WalletHudUpdater WalletHudUpdater { get; private set; }
}