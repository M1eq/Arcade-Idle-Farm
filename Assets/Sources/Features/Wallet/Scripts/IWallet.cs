using UnityEngine.Events;

public interface IWallet
{
    int CoinsAmount { get; }
    event UnityAction CoinsAmountChanged;
    void AddCoins(int amount);
}