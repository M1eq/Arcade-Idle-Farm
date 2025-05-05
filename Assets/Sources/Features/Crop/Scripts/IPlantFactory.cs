using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IPlantFactory
{
    UniTask<GameObject> Create(PlantType plantType, Transform parent);
}