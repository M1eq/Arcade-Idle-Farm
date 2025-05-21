using UnityEngine;

public interface ICollector
{
    public void Collect(Transform parent, CollectableType type, int value);
}