using System;
using UnityEngine;

[Serializable]
public class CropTileConfig
{
    [field: SerializeField] public Color DefaultColor { get; private set; }
    [field: SerializeField] public Color WateredColor { get; private set; }
    [field: Space(10), SerializeField] public float WateredDuration { get; private set; }
    [field: SerializeField] public float[] RestoreDefaultDurations { get; private set; }
}