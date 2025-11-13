using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameProgressSaver : MonoBehaviour
{
    private IGameProgressService _gameProgressService;

    [Inject]
    public void Construct(IGameProgressService gameProgressService)
    {
        _gameProgressService = gameProgressService;
    }

    private void OnApplicationQuit() =>
        SaveProgress();

#if !UNITY_EDITOR
    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus == false)
            SaveProgress();
    }
    
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            SaveProgress();
    }
#endif
    
    private void SaveProgress() => 
        _gameProgressService.SaveProgressAsync().Forget();
}