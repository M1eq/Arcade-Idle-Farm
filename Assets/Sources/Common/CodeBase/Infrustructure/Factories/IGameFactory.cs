using Cysharp.Threading.Tasks;

public interface IGameFactory
{
    void CreateGameRoot();
    UniTask CreatePlayer();
    UniTask<Level> CreateLevel(LevelType levelType);
}