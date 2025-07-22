using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IItemCellFactory
{
    UniTask<ItemCell> Create(PlantType type, Transform parent);
}
