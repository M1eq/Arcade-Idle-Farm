using UnityEngine;

public class AbilitiesAnimationEvents : MonoBehaviour
{
    [SerializeField] private ParticleSystem _seedParticle;
    [SerializeField] private HarvestAbility _harvestAbility;

    public void PlaySeedParticle() =>
        _seedParticle.Play();

    public void ApplyHarvestOverlap() => 
        _harvestAbility.ActivateOverlap();
}