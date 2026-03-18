using Cysharp.Threading.Tasks;
using UnityEngine;

public class ParticleFactory : IParticleFactory
{
    private readonly IAssetProvider _assetProvider;

    public ParticleFactory(IAssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
    }

    public async UniTask<ParticleSystem> CreateHarvestCornParticle(Transform parent, int cornAmount) => 
        await CreatePlantParticle(parent, cornAmount, AssetPath.HarvestCornParticle);
    
    public async UniTask<ParticleSystem> CreateHarvestCarrotParticle(Transform parent, int carrotAmount) => 
        await CreatePlantParticle(parent, carrotAmount, AssetPath.HarvestCarrotParticle);

    private async UniTask<ParticleSystem> CreatePlantParticle(Transform parent, int cornAmount, string assetPath)
    {
        GameObject plantParticlePrefab = await _assetProvider.Load<GameObject>(assetPath);
        GameObject plantParticle = Object.Instantiate(plantParticlePrefab, parent);
        
        ParticleSystem particleSystem = plantParticle.GetComponent<ParticleSystem>();
        particleSystem.emission.SetBurst(0, new ParticleSystem.Burst(0f, cornAmount));
        
        return particleSystem;
    }
}