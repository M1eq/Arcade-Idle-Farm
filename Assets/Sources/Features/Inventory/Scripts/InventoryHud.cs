using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class InventoryHud : MonoBehaviour
{
    [SerializeField] private Transform _cellsContainer;

    private readonly Dictionary<PlantType, UniTask> _pendingTasks = new();
    private readonly Dictionary<PlantType, int> _pendingAmounts = new();
    private readonly Dictionary<PlantType, ItemCell> _itemsCells = new();
    private readonly List<ItemCell> _freeCellsPool = new();

    private IItemCellFactory _itemCellFactory;
    private IStaticDataService _staticData;

    [Inject]
    public void Construct(IItemCellFactory itemCellFactory, IStaticDataService staticData)
    {
        _staticData = staticData;
        _itemCellFactory = itemCellFactory;
    }
    
    public async UniTask Set(PlantType type, int amount)
    {
        if (_pendingTasks.ContainsKey(type))
        {
            _pendingAmounts[type] = amount;
            return;
        }
        
        if (_itemsCells.TryGetValue(type, out var itemCell))
        {
            if (amount <= 0)
                ReturnCellToPool(type, itemCell);
            else
                itemCell.SetAmount(amount);
        }
        else if (amount > 0)
        {
            await InitializeNewCell(type, amount);
        }
    }

    private async UniTask InitializeNewCell(PlantType type, int amount)
    {
        if (_pendingTasks.TryGetValue(type, out var existingTask))
        {
            await existingTask;
            return;
        }

        var task = CreateOrGetCell(type, amount);
        _pendingTasks[type] = task;

        try
        {
            await task;

            if (_pendingAmounts.TryGetValue(type, out var latestAmount))
            {
                _itemsCells[type].SetAmount(latestAmount);
                _pendingAmounts.Remove(type);
            }
        }
        finally
        {
            _pendingTasks.Remove(type);
        }
    }

    private async UniTask CreateOrGetCell(PlantType type, int amount)
    {
        if (_freeCellsPool.Count > 0)
            GetCellFromPool(type, amount);
        else
            await CreateCell(type, amount);
    }

    private async UniTask CreateCell(PlantType type, int amount)
    {
        ItemCell itemCell = await _itemCellFactory.Create(type, _cellsContainer);
        
        itemCell.SetAmount(amount);
        _itemsCells.Add(type, itemCell);
    }

    private void GetCellFromPool(PlantType type, int amount)
    {
        var freeItemCell = _freeCellsPool.First();
        _freeCellsPool.Remove(freeItemCell);

        freeItemCell.SetAmount(amount);
        freeItemCell.SetIcon(_staticData.GetPlantConfig(type).Icon);
    }

    private void ReturnCellToPool(PlantType type, ItemCell itemCell)
    {
        itemCell.HideAndReset();

        _freeCellsPool.Add(itemCell);
        _itemsCells.Remove(type);
    }
}