using TMPro;
using UnityEngine;

public class WalletHud : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsAmountTMP;

    public void SetCoins(int amount) => 
        _coinsAmountTMP.text = amount.ToString();
}