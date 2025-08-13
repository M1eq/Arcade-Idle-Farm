using System;
using Cysharp.Threading.Tasks;

public interface IGameProgressService
{
    public event Action ProgressLoaded;
    GameProgress Progress { get; }
    void ApplyProgress();
    UniTask SaveProgressAsync();
    UniTask LoadProgressAsync();
    UniTask<bool> SavedProgressExists();
    void InitializeNewProgress();
}