using System;
using UnityEngine;

[Serializable]
public class NewProgressConfig
{
    [field: SerializeField] public NewWalletDataConfig NewWalletDataConfig { get; private set; }
}