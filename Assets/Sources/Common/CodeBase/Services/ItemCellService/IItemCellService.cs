using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IItemCellService
{
    UniTask<ItemCell> Create(PlantType type, Transform parent);
}
