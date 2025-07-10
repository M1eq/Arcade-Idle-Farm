using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IPlantFactory
{
    UniTask<Plant> Create(PlantType plantType, Transform parent);
}