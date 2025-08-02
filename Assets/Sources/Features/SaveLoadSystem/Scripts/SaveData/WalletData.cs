using System;

[Serializable]
public sealed class WalletData : ISaveData
{
    public int Coins { get; private set; }
    
    public WalletData(int coins)
    {
        Coins = coins;
    }

    public bool EqualsData(WalletData data) => 
        throw new NotImplementedException();

    public WalletData Clone() =>
        new(Coins);

    public void UpdateData(IWallet wallet) => 
        Coins = wallet.CoinsAmount;
}