using UnityEngine;
using Zenject;

public class WalletHudUpdater : MonoBehaviour
{
    [SerializeField] private WalletHud _walletHud;
    
    private IWallet _wallet;
    
    [Inject]
    public void Construct(IWallet wallet)
    {
        _wallet = wallet;
    }

    private void Start() => 
        SubscribeUpdates();
    
    private void OnDestroy() => 
        CleanUp();

    private void SubscribeUpdates() => 
        _wallet.CoinsAmountChanged += OnCoinsAmountChanged;
    
    private void CleanUp() => 
        _wallet.CoinsAmountChanged -= OnCoinsAmountChanged;
    
    private void OnCoinsAmountChanged(int amount) => 
        _walletHud.SetCoins(amount);
}