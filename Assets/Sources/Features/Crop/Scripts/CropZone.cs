using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CropZone : MonoBehaviour
{
    public event UnityAction InteractionFinished;

    public CropZoneInteractionType InteractionType { get; private set; } = CropZoneInteractionType.Seed;

    [SerializeField] private PlantType _plantType;
    [Space(10), SerializeField] private CropTile[] _cropTiles;

    private readonly List<CropTile> _sowedCropTiles = new();
    private readonly List<CropTile> _wateredCropTiles = new();

    private void Start() =>
        InitializeCropTiles();

    private void OnEnable() =>
        SubscribeUpdates();

    private void OnDisable() =>
        CleanUp();

    private void OnCropTileSowed(CropTile sowedTile) => 
        HandleCropTileInteraction(sowedTile, _sowedCropTiles, CropZoneInteractionType.Water);

    private void OnCropTileWatered(CropTile wateredTile) => 
        HandleCropTileInteraction(wateredTile, _wateredCropTiles, CropZoneInteractionType.Seed);
    
    private void SubscribeUpdates()
    {
        foreach (CropTile cropTile in _cropTiles)
        {
            cropTile.Sowed += OnCropTileSowed;
            cropTile.Watered += OnCropTileWatered;
        }
    }

    private void CleanUp()
    {
        foreach (CropTile cropTile in _cropTiles)
        {
            cropTile.Sowed -= OnCropTileSowed;
            cropTile.Watered -= OnCropTileWatered;
        }
    }

    private void InitializeCropTiles()
    {
        foreach (CropTile cropTile in _cropTiles)
            cropTile.Initialize(_plantType);
    }
    
    private void HandleCropTileInteraction(CropTile tile, List<CropTile> interactedTiles, 
        CropZoneInteractionType nextInteractionType)
    {
        if (interactedTiles.Contains(tile) == false) 
            interactedTiles.Add(tile);

        if (interactedTiles.Count == _cropTiles.Length)
        {
            InteractionType = nextInteractionType;
            InteractionFinished?.Invoke();
        }
    }
}