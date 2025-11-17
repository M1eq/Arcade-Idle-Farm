using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameFactory : IGameFactory
{
    private const string GameRootName = "GameRoot";

    private readonly IInstantiator _instantiator;
    private readonly IAssetProvider _assetProvider;
    private readonly IStaticDataService _staticDataService;
    private readonly IGameProgressService _gameProgressService;

    private Transform _gameRoot;
    private Vector3 _playerSpawnPosition;

    public GameFactory(IInstantiator instantiator, IAssetProvider assetProvider,
        IStaticDataService staticDataService, IGameProgressService gameProgressService)
    {
        _instantiator = instantiator;
        _assetProvider = assetProvider;
        _staticDataService = staticDataService;
        _gameProgressService = gameProgressService;
    }

    public void CreateGameRoot()
    {
        GameObject root = new GameObject(GameRootName);
        _gameRoot = root.transform;
    }

    public async UniTask CreatePlayer()
    {
        GameObject prefab = await _assetProvider.Load<GameObject>(AssetPath.Player);

        var player = _instantiator.InstantiatePrefabForComponent<Player>(prefab, _gameRoot);
        var playerConfig = _staticDataService.GameConfig.PlayerConfig;

        player.Initialize(playerConfig);

        var movement = player.GetComponent<PlayerMovement>();
        movement.Initialize(playerConfig.MovementConfig);

        var animator = player.GetComponent<MovementAnimationUpdater>();
        animator.Initialize(playerConfig.AnimatorConfig);

        var bending = player.GetComponent<Bending>();
        bending.Initialize(playerConfig.BendingConfig);

        player.transform.SetParent(_gameRoot);
        player.transform.position = _playerSpawnPosition;

        await CreateFollowCamera(player.transform);
    }

    public async UniTask<Level> CreateLevel(LevelType levelType)
    {
        LevelStaticData levelConfig = _staticDataService.GetLevelConfig(levelType);
        GameConfig gameConfig = _staticDataService.GameConfig; 
        
        GameObject prefab = await _assetProvider.Load<GameObject>(levelConfig.PrefabReference);
        var level = _instantiator.InstantiatePrefabForComponent<Level>(prefab, _gameRoot);
        
        level.InitializeInteractionZones(gameConfig.CropZoneConfig, gameConfig.PlantSellZoneConfig);
        _playerSpawnPosition = level.PlayerSpawnPoint.position;

        return level;
    }

    private async UniTask CreateFollowCamera(Transform followTarget)
    {
        GameObject prefab = await _assetProvider.Load<GameObject>(AssetPath.FollowCamera);

        var followCamera = _instantiator.InstantiatePrefabForComponent<FollowCamera>(prefab, _gameRoot);
        var followCameraConfig = _staticDataService.GameConfig.PlayerConfig.FollowCameraConfig;
        var followCameraUpdater = followCamera.GetComponent<FollowCameraUpdater>();

        followCameraUpdater.Initialize(followCameraConfig);
        followCamera.SetTarget(followTarget);
    }
}