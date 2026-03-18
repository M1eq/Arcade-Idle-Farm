using System;
using UnityEngine;

[Serializable]
public sealed class WalletData : ISaveData
{
    public int Coins => _coins;
    
    [SerializeField] private int _coins;
    
    public WalletData(int coins)
    {
        _coins = coins;
    }

    public bool EqualsData(WalletData data)
    {  
        bool coinsEquals = _coins == data.Coins;
        return coinsEquals;
    }

    public WalletData Clone() =>
        new(_coins);

    public void UpdateData(IWallet wallet) => 
        _coins = wallet.CoinsAmount;
}