using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractionButton : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Button _interactionButton;

    public void Initialize(InteractionButtonStaticData config, Action clickReaction)
    {
        InitializeIcon(config);
        InitializeButton(clickReaction);
    }
    
    private void OnDestroy() =>
        CleanUp();
    
    private void InitializeButton(Action onClick)
    {
        _interactionButton.onClick.AddListener(onClick.Invoke);
        _interactionButton.onClick.AddListener(() => Destroy(gameObject));
    }

    private void InitializeIcon(InteractionButtonStaticData config) => 
        _icon.sprite = config.Icon;
    
    private void CleanUp() =>
        _interactionButton.onClick.RemoveAllListeners();
}