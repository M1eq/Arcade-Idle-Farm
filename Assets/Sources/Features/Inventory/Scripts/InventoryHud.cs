using System;
using TMPro;
using UnityEngine;

public class InventoryHud : MonoBehaviour
{
    [SerializeField] private TMP_Text _cornAmountTMP;

    public void Set(PlantType type, int amount)
    {
        switch (type)
        {
            case PlantType.Corn:
                _cornAmountTMP.text = amount.ToString();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}