using System;
using UnityEngine;

[Serializable]
public class BendingConfig 
{
    [field: SerializeField] public string PositionReference { get; set; }
    [field: SerializeField] public Material[] BendingTargets { get; set; }
}
