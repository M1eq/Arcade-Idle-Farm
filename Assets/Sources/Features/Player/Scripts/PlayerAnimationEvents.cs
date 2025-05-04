using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] private ParticleSystem _seedParticle;

    public void PlaySeedParticle() => 
        _seedParticle.Play();
}
