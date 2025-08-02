using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public interface IGameFactory
{
    List<IProgressReader> ProgressReaders { get; }
    void CreateGameRoot();
    UniTask CreatePlayer();
    UniTask CreateLevel();
}