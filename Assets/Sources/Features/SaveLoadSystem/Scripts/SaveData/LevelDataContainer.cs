using System;
using UnityEngine;

[Serializable]
public class LevelDataContainer
{
    [field: SerializeField] public LevelType LevelType { get; private set; }
    [field: SerializeField] public LevelData LevelData { get; private set; }
}