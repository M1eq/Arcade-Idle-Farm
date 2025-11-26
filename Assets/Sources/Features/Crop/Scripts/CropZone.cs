using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CropZone : MonoBehaviour
{
    public event UnityAction InteractionFinished;

    public CropZoneInteractionType InteractionType { get; private set; } = CropZoneInteractionType.Seed;
    public string ID => _uniqueID.Id;
    
    [SerializeField] private PlantType _plantType;
    [SerializeField] private UniqueID _uniqueID;
    
    [Space(10), SerializeField] private CropTile[] _cropTiles;

    private readonly List<CropTile> _sowedCropTiles = new();
    private readonly List<CropTile> _wateredCropTiles = new();
    private readonly List<CropTile> _harvestedCropTiles = new();
    
    private CropZoneConfig _config;

    public void RestoreBy(CropZoneData cropZoneData)
    {
        InteractionType = cropZoneData.InteractionType;
        
        foreach (var cropTile in _cropTiles)
        {
            if (cropZoneData.TryGetCropTileDataBy(cropTile.ID, out var cropTileData)) 
                cropTile.RestoreBy(cropTileData);
            
            //если cropTile нет в data, восстанавливать ему минимальное состояние других тайлов
        }
    }

    public List<CropTileData> GetCropTilesDataList()
    {
        List<CropTileData> cropTilesDataList = new();
        
        foreach (var cropTile in _cropTiles)
        {
            CropTileData cropTileData = new(cropTile.ID, cropTile.CropTileState);
            cropTilesDataList.Add(cropTileData);
        }
        
        return cropTilesDataList;
    }
    
    public void Initialize(CropZoneConfig cropZoneConfig) =>
        _config = cropZoneConfig;
    
    private void Start() =>
        InitializeCropTiles();

    private void OnEnable() =>
        SubscribeUpdates();

    private void OnDisable() =>
        CleanUp();

    private void OnCropTileSowed(CropTile sowedTile) =>
        HandleCropTileInteraction(sowedTile, _sowedCropTiles, CropZoneInteractionType.Water);

    private void OnCropTileWatered(CropTile wateredTile) =>
        HandleCropTileInteraction(wateredTile, _wateredCropTiles, CropZoneInteractionType.Harvest);

    private void OnCropTileHarvested(CropTile harvestedTile) => 
        HandleCropTileInteraction(harvestedTile, _harvestedCropTiles, CropZoneInteractionType.Seed);
    
    private void InitializeCropTiles()
    {
        foreach (CropTile cropTile in _cropTiles)
            cropTile.Initialize(_plantType, _config.CropTileConfig);
    }

    private void HandleCropTileInteraction(CropTile tile, List<CropTile> interactedTiles,
        CropZoneInteractionType nextInteractionType)
    {
        if (interactedTiles.Contains(tile) == false)
            interactedTiles.Add(tile);

        if (interactedTiles.Count == _cropTiles.Length)
        {
            interactedTiles.Clear();
            InteractionType = nextInteractionType;
            InteractionFinished?.Invoke();
        }
    }
    
    private void SubscribeUpdates()
    {
        foreach (CropTile cropTile in _cropTiles)
        {
            cropTile.Sowed += OnCropTileSowed;
            cropTile.Watered += OnCropTileWatered;
            cropTile.Harvested += OnCropTileHarvested;
        }
    }

    private void CleanUp()
    {
        foreach (CropTile cropTile in _cropTiles)
        {
            cropTile.Sowed -= OnCropTileSowed;
            cropTile.Watered -= OnCropTileWatered;
            cropTile.Harvested -= OnCropTileHarvested;
        }
    }
}