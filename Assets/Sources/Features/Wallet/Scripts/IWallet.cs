using UnityEngine.Events;

public interface IWallet
{
    event UnityAction<int> CoinsAmountChanged;
    void AddCoins(int amount);
}