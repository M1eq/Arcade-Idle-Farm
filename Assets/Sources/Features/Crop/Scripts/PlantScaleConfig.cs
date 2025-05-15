using System;
using UnityEngine;

[Serializable]
public class PlantScaleConfig
{
    [field: SerializeField] public float SeedScaleDuration { get; private set; }
    [field: SerializeField] public float WateredScaleDuration { get; private set; }
    [field: Space(10), SerializeField] public Vector3 SeedScale { get; private set; }
    [field: SerializeField] public Vector3 WateredScale { get; private set; }
}
