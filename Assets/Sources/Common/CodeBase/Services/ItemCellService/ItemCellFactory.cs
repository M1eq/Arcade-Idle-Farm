using Cysharp.Threading.Tasks;
using UnityEngine;

public class ItemCellFactory : IItemCellService
{
    private readonly IHudFactory _hudFactory;

    public ItemCellFactory(IHudFactory hudFactory)
    {
        _hudFactory = hudFactory;
    }
    
    public async UniTask<ItemCell> Create(PlantType type, Transform parent) => 
        await _hudFactory.CreateItemCell(type, parent);
}
