using Cysharp.Threading.Tasks;
using UnityEngine;

public class ParticleFactory : IParticleFactory
{
    private readonly IAssetProvider _assetProvider;

    public ParticleFactory(IAssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
    }

    public async UniTask<ParticleSystem> CreateHarvestCornParticle(Transform parent, int cornAmount)
    {
        GameObject cornParticlePrefab = await _assetProvider.Load<GameObject>(AssetPath.HarvestCornParticle);
        GameObject cornParticle = Object.Instantiate(cornParticlePrefab, parent);
        
        ParticleSystem cornParticleSystem = cornParticle.GetComponent<ParticleSystem>();
        cornParticleSystem.emission.SetBurst(0, new ParticleSystem.Burst(0f, cornAmount));
        
        return cornParticleSystem;
    }
}