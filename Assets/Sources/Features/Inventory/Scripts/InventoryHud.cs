using TMPro;
using UnityEngine;

public class InventoryHud : MonoBehaviour
{
    [SerializeField] private TMP_Text _cornAmountTMP;

    public void SetCornAmount(int amount) => 
        _cornAmountTMP.text = amount.ToString();
}