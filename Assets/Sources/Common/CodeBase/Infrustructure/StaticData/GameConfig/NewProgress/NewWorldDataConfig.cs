using System;
using UnityEngine;

[Serializable]
public class NewWorldDataConfig
{
    [field: SerializeField] public LevelType StartLevelType { get; private set; }
}