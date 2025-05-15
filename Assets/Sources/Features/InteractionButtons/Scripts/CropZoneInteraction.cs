using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class CropZoneInteraction : MonoBehaviour
{
    private IInteractionButtonService _interactionButtonService;
    private CancellationTokenSource _buttonCancellation;
    private InteractionButton _interactionButton;
    
    private IAbility _currentAbility;
    private SowAbility _sowAbility;
    private WaterAbility _waterAbility;

    [Inject]
    public void Construct(IInteractionButtonService interactionButtonService)
    {
        _interactionButtonService = interactionButtonService;
    }

    public void Initialize(Collider other) => 
        Cache(other);

    public void SuggestInteraction(CropZoneInteractionType interactionType)
    {
        switch (interactionType)
        {
            case CropZoneInteractionType.Seed:
                ShowInteractionButton(InteractionButtonType.Seed, _sowAbility);
                break;
            
            case CropZoneInteractionType.Water:
                ShowInteractionButton(InteractionButtonType.Water, _waterAbility);
                break;
        }
    }

    public void StopInteraction()
    {
        if (_currentAbility != null)
            _currentAbility.Stop();
    }

    public void ResetInteraction()
    {
        CancelButtonAwait();
        DestroyInteractionButton();
        StopInteraction();
    }

    private void Cache(Collider source)
    {
        CacheAbility(source, ref _sowAbility);
        CacheAbility(source, ref _waterAbility);
    }

    private void CacheAbility<TAbility>(Collider source, ref TAbility abilityField) where TAbility : IAbility
    {
        if (abilityField == null && source.gameObject.TryGetComponent(out TAbility ability))
            abilityField = ability;
    }

    private void ShowInteractionButton(InteractionButtonType interactionButtonType, IAbility ability)
    {
        _currentAbility = ability;
        ShowInteractionButtonAsync(interactionButtonType, _currentAbility.Apply).Forget();
    }

    private async UniTask ShowInteractionButtonAsync(InteractionButtonType type, Action onClick)
    {
        CancelButtonAwait();
        DestroyInteractionButton();
        
        _buttonCancellation = new CancellationTokenSource();

        _interactionButton = await _interactionButtonService.Show(type, onClick)
            .AttachExternalCancellation(_buttonCancellation.Token);
    }

    private void CancelButtonAwait()
    {
        _buttonCancellation?.Cancel();
        _buttonCancellation?.Dispose();
        _buttonCancellation = null;
    }

    private void DestroyInteractionButton()
    {
        if (_interactionButton == null) 
            return;
        
        Destroy(_interactionButton.gameObject);
        _interactionButton = null;
    }
}