using UnityEngine;
using Zenject;

public class WalletHudUpdater : MonoBehaviour, IProgressReader
{
    public bool UpdatesSubscribed { get; private set; }

    [SerializeField] private WalletHud _walletHud;

    private IWallet _wallet;

    [Inject]
    public void Construct(IWallet wallet)
    {
        _wallet = wallet;
    }

    public void ApplyProgress(GameProgress progress) => 
        UpdateWalletHud(progress.WalletData.Coins);

    private void Start() =>
        SubscribeUpdates();

    private void OnDestroy() =>
        CleanUp();

    private void OnCoinsAmountChanged() =>
        UpdateWalletHud(_wallet.CoinsAmount);

    private void UpdateWalletHud(int coinsAmount) =>
        _walletHud.SetCoins(coinsAmount);

    private void SubscribeUpdates()
    {
        _wallet.CoinsAmountChanged += OnCoinsAmountChanged;
        UpdatesSubscribed = true;
    }

    private void CleanUp()
    {
        _wallet.CoinsAmountChanged -= OnCoinsAmountChanged;
        UpdatesSubscribed = false;
    }
}