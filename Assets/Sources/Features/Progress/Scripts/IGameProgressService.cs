using Cysharp.Threading.Tasks;

public interface IGameProgressService
{
    GameProgress Progress { get; }
    void ApplyProgress();
    UniTask SaveProgressAsync();
    UniTask LoadProgressAsync();
    UniTask<bool> SavedProgressExists();
    void InitializeNewProgress();
}