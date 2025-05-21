using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IParticleFactory
{
    UniTask<ParticleSystem> CreateHarvestCornParticle(Transform parent, int cornAmount);
}