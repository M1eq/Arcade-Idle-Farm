using Cysharp.Threading.Tasks;
using UnityEngine;

public class Collector : ICollector
{
    private readonly IParticleFactory _particleFactory;
    private readonly IInventory _inventory;

    public Collector(IParticleFactory particleFactory, IInventory inventory)
    {
        _particleFactory = particleFactory;
        _inventory = inventory;
    }
    
    public void Collect(Transform parent, CollectableType type, int value)
    {
        switch (type)
        {
            case CollectableType.Corn:
                 _particleFactory.CreateHarvestCornParticle(parent, value).Forget();
                 _inventory.Add(PlantType.Corn, value);
                break;
        }
    }
}
