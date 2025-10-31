using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractionButton : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Button _interactionButton;

    public void Initialize(InteractionButtonStaticData config, Action clickReaction)
    {
        SetIcon(config.Icon);
        SetButtonClickReaction(clickReaction);
    }
    
    private void OnDestroy() =>
        CleanUp();
    
    private void SetIcon(Sprite icon) => 
        _icon.sprite = icon;
    
    private void SetButtonClickReaction(Action onClick)
    {
        _interactionButton.onClick.AddListener(onClick.Invoke);
        _interactionButton.onClick.AddListener(() => Destroy(gameObject));
    }
    
    private void CleanUp() =>
        _interactionButton.onClick.RemoveAllListeners();
}