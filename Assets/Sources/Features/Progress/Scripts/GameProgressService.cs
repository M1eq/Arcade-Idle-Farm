using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

public sealed class GameProgressService : IGameProgressService
{
    public event Action ProgressLoaded;
    public GameProgress Progress { get; private set; }

    private bool PlayerDataUpdated => _cachedProgress.PlayerData.EqualsData(Progress.PlayerData) == false;
    private bool WorldDataUpdated => _cachedProgress.WorldData.EqualsData(Progress.WorldData) == false;
    private bool WalletDataUpdated => _cachedProgress.WalletData.EqualsData(Progress.WalletData) == false;

    private GameProgress _cachedProgress;
    private readonly ISaveSystem _saveSystem;
    private readonly IGameFactory _gameFactory;
    private readonly ISaveDataFactory _saveDataFactory;
    
    private CancellationTokenSource _playerSaveCancellationToken;
    private CancellationTokenSource _worldSaveCancellationToken;
    private CancellationTokenSource _walletSaveCancellationToken;

    public GameProgressService(ISaveSystem saveSystem, IGameFactory gameFactory, ISaveDataFactory saveDataFactory)
    {
        _saveSystem = saveSystem;
        _gameFactory = gameFactory;
        _saveDataFactory = saveDataFactory;
    }

    public void ApplyProgress()
    {
        foreach (var progressReader in _gameFactory.ProgressReaders)
            progressReader.ApplyProgress(Progress);
    }

    public async UniTask SaveProgressAsync()
    {
        CancelCurrentSaves();
        ResetCancellationTokens();
        
        var tasks = new List<UniTask>();
        
        if (PlayerDataUpdated || await _saveSystem.ExistsAsync<PlayerData>() == false)
            tasks.Add(SaveDataAsync(Progress.PlayerData, _playerSaveCancellationToken));

        if (WorldDataUpdated || await _saveSystem.ExistsAsync<WorldData>() == false)
            tasks.Add(SaveDataAsync(Progress.WorldData, _worldSaveCancellationToken));
        
        if (WalletDataUpdated || await _saveSystem.ExistsAsync<WalletData>() == false)
            tasks.Add(SaveDataAsync(Progress.WalletData, _walletSaveCancellationToken));

        await UniTask.WhenAll(tasks);
        _cachedProgress = Progress.Clone();
    }
    
    public async UniTask LoadProgressAsync()
    {
        var playerData = await _saveSystem.LoadAsync<PlayerData>();
        var worldData = await _saveSystem.LoadAsync<WorldData>();
        var walletData = await _saveSystem.LoadAsync<WalletData>();

        Progress = new GameProgress(playerData, worldData, walletData);
        _cachedProgress = Progress.Clone();
        
        ProgressLoaded?.Invoke();
    }

    public async UniTask<bool> SavedProgressExists()
    {
        var playerDataExists = await _saveSystem.ExistsAsync<PlayerData>();
        var worldDataExists = await _saveSystem.ExistsAsync<WorldData>();
        var walletDataExists = await _saveSystem.ExistsAsync<WalletData>();
        
        return playerDataExists && worldDataExists && walletDataExists;
    }

    public void InitializeNewProgress()
    {
        PlayerData playerData = _saveDataFactory.CreateNewPlayerData();
        WorldData worldData = _saveDataFactory.CreateNewWorldData();
        WalletData walletData = _saveDataFactory.CreateNewWalletData();
        
        Progress = new GameProgress(playerData, worldData, walletData);
        _cachedProgress = Progress.Clone();
        
        ProgressLoaded?.Invoke();
    }
    
    private void CancelCurrentSaves()
    {
        _playerSaveCancellationToken?.Cancel();
        _worldSaveCancellationToken?.Cancel();
        _walletSaveCancellationToken?.Cancel();
    }

    private void ResetCancellationTokens()
    {
        _playerSaveCancellationToken = new CancellationTokenSource();
        _worldSaveCancellationToken = new CancellationTokenSource();
        _walletSaveCancellationToken = new CancellationTokenSource();
    }
    
    private async UniTask SaveDataAsync<T>(T data, CancellationTokenSource cancellationToken) where T : ISaveData
    {
        try 
        {
            await _saveSystem.SaveAsync(data)
                .AttachExternalCancellation(cancellationToken.Token);
        }
        catch (OperationCanceledException)
        {
            UnityEngine.Debug.LogWarning($"Сохранение {typeof(T).Name} отменено (новые изменения)");
        }
    }
}