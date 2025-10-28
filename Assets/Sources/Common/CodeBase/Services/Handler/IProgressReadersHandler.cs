using System.Collections.Generic;
using UnityEngine;

public interface IProgressReadersHandler
{
    List<IProgressReader> ProgressReaders { get; }
    void RegisterProgressReaders(GameObject prefab);
}