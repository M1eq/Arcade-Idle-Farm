using System.Collections.Generic;
using UnityEngine;

public class ProgressReadersHandler : IProgressReadersHandler
{
    public List<IProgressReader> ProgressReaders { get; } = new();
    
    public void RegisterProgressReaders(GameObject prefab)
    {
        foreach (var progressReader in prefab.GetComponentsInChildren<IProgressReader>())
            ProgressReaders.Add(progressReader);
    }
}