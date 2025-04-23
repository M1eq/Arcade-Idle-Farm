using Cysharp.Threading.Tasks;

public interface IGameFactory
{
    UniTask CreatePlayer();
    UniTask CreateLevel();
}