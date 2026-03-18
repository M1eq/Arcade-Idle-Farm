using UnityEngine;

public class WaterAbility : MonoBehaviour, IAbility
{
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private ParticleSystem _waterParticle;
    
    public void Apply()
    {
        _animator.LaunchWaterAnimation();
        _waterParticle.Play();
    }

    public void Stop()
    {
        _animator.StopWaterAnimation();
        _waterParticle.Stop();
    }
}
 