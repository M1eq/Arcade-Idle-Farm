using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CropZoneInteractionSwitcher : MonoBehaviour
{
    [SerializeField] private CropZone _cropZone;
    [SerializeField] private CropZoneInteraction _cropZoneInteraction;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            Initialize(other);
    }

    private void OnTriggerExit(Collider other) =>
        ResetInteraction();

    private void OnEnable() =>
        SubscribeUpdates();

    private void OnDisable() =>
        CleanUp();

    private void OnInteractionFinished() =>
        SwitchInteractionTo(_cropZone.InteractionType);

    private void SubscribeUpdates() =>
        _cropZone.InteractionFinished += OnInteractionFinished;

    private void CleanUp() =>
        _cropZone.InteractionFinished -= OnInteractionFinished;

    private void ResetInteraction() =>
        _cropZoneInteraction.ResetInteraction();

    private void Initialize(Collider other)
    {
        _cropZoneInteraction.Initialize(other);
        _cropZoneInteraction.SuggestInteraction(_cropZone.InteractionType);
    }

    private void SwitchInteractionTo(CropZoneInteractionType interactionType)
    {
        _cropZoneInteraction.StopInteraction();
        _cropZoneInteraction.SuggestInteraction(interactionType);
    }
}