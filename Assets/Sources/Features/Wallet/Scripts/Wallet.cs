using UnityEngine.Events;

public class Wallet : IWallet
{
    public int CoinsAmount => _coins;
    public event UnityAction CoinsAmountChanged;

    private int _coins;

    public void AddCoins(int amount)
    {
        if (amount <= 0)
            return;

        _coins += amount;
        CoinsAmountChanged?.Invoke();
    }
}