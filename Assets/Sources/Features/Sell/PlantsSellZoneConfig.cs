using System;
using UnityEngine;

[Serializable]
public class PlantsSellZoneConfig
{
    [field: SerializeField] public float SellMultiplierStep { get; private set; } = 300;
}