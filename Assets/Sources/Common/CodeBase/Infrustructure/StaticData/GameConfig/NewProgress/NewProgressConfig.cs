using System;
using UnityEngine;

[Serializable]
public class NewProgressConfig
{
    [field: SerializeField] public NewWalletDataConfig NewWalletDataConfig { get; private set; }
    [field: SerializeField] public NewPlayerDataConfig NewPlayerDataConfig { get; private set; }
    [field: SerializeField] public NewWorldDataConfig NewWorldDataConfig { get; private set; }
}