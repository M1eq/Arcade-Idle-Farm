using Unity.VisualScripting;
using UnityEngine.Events;

public class Wallet : IWallet, IInitializable
{
    public int CoinsAmount => _coins;
    public event UnityAction CoinsAmountChanged;

    private int _coins;
    private readonly IGameProgressService _gameProgressService;

    public Wallet(IGameProgressService gameProgressService)
    {
        _gameProgressService = gameProgressService;
        _coins = _gameProgressService.Progress.WalletData.Coins;
    }
    
    public void Initialize() => 
        CoinsAmountChanged?.Invoke();
    
    public void AddCoins(int amount)
    {
        if (amount <= 0)
            return;

        _coins += amount;
        _gameProgressService.Progress.WalletData.UpdateData(this);
        CoinsAmountChanged?.Invoke();
    }
}