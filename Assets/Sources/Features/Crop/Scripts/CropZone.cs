using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
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

    [Space(10), SerializeField, ReadOnly] private List<CropTile> _sowedCropTiles = new();
    [SerializeField, ReadOnly] private List<CropTile> _wateredCropTiles = new();
    [SerializeField, ReadOnly] private List<CropTile> _harvestedCropTiles = new();

    private CropZoneConfig _config;

    public List<CropTileData> GetSowedCropTilesData() => GetCropTileData(_sowedCropTiles);
    public List<CropTileData> GetWateredCropTilesData() => GetCropTileData(_wateredCropTiles);
    public List<CropTileData> GetHarvestedCropTilesData() => GetCropTileData(_harvestedCropTiles);
    
    public void RestoreBy(CropZoneData cropZoneData)
    {
        InteractionType = cropZoneData.InteractionType;
        
        InitializeCropTiles();
        RestoreInteractedTiles(cropZoneData);
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
        HandleCropTileInteraction(sowedTile, _harvestedCropTiles, _sowedCropTiles, CropZoneInteractionType.Water);

    private void OnCropTileWatered(CropTile wateredTile) => 
        HandleCropTileInteraction(wateredTile, _sowedCropTiles,_wateredCropTiles, CropZoneInteractionType.Harvest);

    private void OnCropTileHarvested(CropTile harvestedTile) => 
        HandleCropTileInteraction(harvestedTile, _wateredCropTiles, _harvestedCropTiles, CropZoneInteractionType.Seed);

    private void HandleCropTileInteraction(CropTile tile, List<CropTile> previouslyInteractedTiles,
        List<CropTile> targetInteractedTiles, CropZoneInteractionType nextInteractionType)
    {
        if (previouslyInteractedTiles.Contains(tile))
            previouslyInteractedTiles.Remove(tile);
        
        if (targetInteractedTiles.Contains(tile) == false)
            targetInteractedTiles.Add(tile);

        if (targetInteractedTiles.Count == _cropTiles.Length)
        {
            InteractionType = nextInteractionType;
            InteractionFinished?.Invoke();
        }
    }

    private void InitializeCropTiles()
    {
        foreach (CropTile cropTile in _cropTiles)
            cropTile.Initialize(_plantType, _config.CropTileConfig);
    }

    private void RestoreInteractedTiles(CropZoneData cropZoneData)
    {
        List<CropTile> restoredSowedCropTiles = GetRestoredCropTilesBy(
            CropTileState.Sowed, cropZoneData.SowedCropTilesData);

        List<CropTile> restoredWateredCropTiles = GetRestoredCropTilesBy(
            CropTileState.Watered, cropZoneData.WateredCropTilesData);

        List<CropTile> restoredHarvestedCropTiles = GetRestoredCropTilesBy(
            CropTileState.Empty, cropZoneData.HarvestedCropTilesData);
        
        _sowedCropTiles = new List<CropTile>(restoredSowedCropTiles);
        _wateredCropTiles = new List<CropTile>(restoredWateredCropTiles);
        _harvestedCropTiles = new List<CropTile>(restoredHarvestedCropTiles);
    }

    private List<CropTile> GetRestoredCropTilesBy(CropTileState cropTileState, List<CropTileData> cropTilesDataList)
    {
        List<CropTile> restoredCropTilesList = new();

        foreach (var cropTile in cropTilesDataList)
        {
            var cropTileById = _cropTiles.FirstOrDefault(x => x.ID == cropTile.ID);

            if (cropTileById != null)
            {
                if (cropTileState != CropTileState.Empty)
                    cropTileById.RestoreTo(cropTileState);

                if (restoredCropTilesList.Contains(cropTileById) == false)
                    restoredCropTilesList.Add(cropTileById);
            }
        }

        return restoredCropTilesList;
    }

    private List<CropTileData> GetCropTileData(List<CropTile> cropTiles) => 
        cropTiles.Select(cropTile => new CropTileData(cropTile.ID)).ToList();
    
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