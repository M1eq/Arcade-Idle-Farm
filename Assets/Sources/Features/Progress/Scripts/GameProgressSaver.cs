using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameProgressSaver : MonoBehaviour
{
    private IGameProgressService _gameProgressService;
    private ISessionInfo _sessionInfo;

    [Inject]
    public void Construct(IGameProgressService gameProgressService, ISessionInfo sessionInfo)
    {
        _sessionInfo = sessionInfo;
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
    
    private void SaveProgress()
    {
        UpdateLevelData();
        _gameProgressService.SaveProgressAsync().Forget();
    }

    private void UpdateLevelData()
    {
        _gameProgressService.Progress.WorldData.UpdateLevelDataFor(
            _sessionInfo.Level.LevelType, _sessionInfo.Level);
    }
}