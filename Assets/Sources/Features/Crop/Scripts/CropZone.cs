using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CropZone : MonoBehaviour
{
    public event UnityAction InteractionFinished;
    
    public CropZoneInteractionType InteractionType { get; private set; } = CropZoneInteractionType.Seed;
    
    private bool AllTilesSowed => _sowedCropTiles.Count == _cropTiles.Length;
    
    [SerializeField] private PlantType _plantType;
    [Space(10), SerializeField] private CropTile[] _cropTiles;

    private readonly List<CropTile> _sowedCropTiles = new();
    
    private void Start() =>
        InitializeCropTiles();

    private void OnEnable() =>
        SubscribeUpdates();

    private void OnDisable() =>
        CleanUp();
    
    private void OnCropTileSowed(CropTile sowedTile)
    {
        if (_sowedCropTiles.Contains(sowedTile) == false)
            _sowedCropTiles.Add(sowedTile);

        if (AllTilesSowed) 
            InteractionFinished?.Invoke();
    }
    
    private void SubscribeUpdates()
    {
        foreach (CropTile cropTile in _cropTiles)
            cropTile.Sowed += OnCropTileSowed;
    }

    private void CleanUp()
    {
        foreach (CropTile cropTile in _cropTiles)
            cropTile.Sowed -= OnCropTileSowed;
    }
    
    private void InitializeCropTiles()
    {
        foreach (CropTile cropTile in _cropTiles)
            cropTile.Initialize(_plantType);
    }
}