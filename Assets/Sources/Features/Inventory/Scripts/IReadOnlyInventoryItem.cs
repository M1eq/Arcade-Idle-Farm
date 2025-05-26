public interface IReadOnlyInventoryItem
{
    PlantType Type { get; }
    int Amount { get; }
}