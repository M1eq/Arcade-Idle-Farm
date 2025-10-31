using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _amountTMP;

    public void Show() => 
        gameObject.SetActive(true);
    
    public void SetIcon(Sprite iconSprite) => 
        _icon.sprite = iconSprite;

    public void SetAmount(int amount) => 
        _amountTMP.text = amount.ToString();
    
    public void HideAndReset()
    {
        gameObject.SetActive(false);
        
        _icon.sprite = null;
        _amountTMP.text = 0.ToString();
    }
}