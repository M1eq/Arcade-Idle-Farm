using Cysharp.Threading.Tasks;

public interface IGameProgressService
{
    GameProgress Progress { get; }
    UniTask ApplyProgressAsync();
    UniTask UpdateProgressAsync();
    UniTask LoadProgressAsync();
}