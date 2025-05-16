using System;
using UnityEngine;

[Serializable]
public class CropTileConfig
{
    [field: SerializeField] public Color DefaultColor { get; private set; }
    [field: SerializeField] public Color WateredColor { get; private set; }
    [field: SerializeField] public float ColorChangeDuration { get; private set; }
}