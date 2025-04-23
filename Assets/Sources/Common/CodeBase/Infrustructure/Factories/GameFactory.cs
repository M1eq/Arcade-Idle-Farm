using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameFactory : IGameFactory
{
    private const string GameRootName = "GameRoot";
    
    private readonly IAssetProvider _assetProvider;
    private readonly IInstantiator _instantiator;
    private readonly IStaticDataService _staticDataService;

    private Transform _gameRoot;
    private Vector3 _playerSpawnPosition;

    public GameFactory(IInstantiator instantiator, IAssetProvider assetProvider, IStaticDataService staticDataService)
    {
        _instantiator = instantiator;
        _assetProvider = assetProvider;
        _staticDataService = staticDataService;
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
        var playerConfig = _staticDataService.GetGameConfig().PlayerConfig;

        var movement = player.GetComponent<PlayerMovement>();
        movement.Initialize(playerConfig.MovementConfig);

        var animator = player.GetComponent<PlayerAnimator>();
        animator.Initialize(playerConfig.AnimatorConfig);

        player.transform.SetParent(_gameRoot);
        player.transform.position = _playerSpawnPosition;
        
        await CreateFollowCamera(player.transform);
    }
    
    public async UniTask CreateLevel()
    {
        GameObject prefab = await _assetProvider.Load<GameObject>(AssetPath.Level);
        var level = _instantiator.InstantiatePrefabForComponent<Level>(prefab, _gameRoot);
        
        _playerSpawnPosition = level.PlayerSpawnPoint.position;
    }
    
    private async UniTask CreateFollowCamera(Transform followTarget)
    {
        GameObject prefab = await _assetProvider.Load<GameObject>(AssetPath.FollowCamera);
        var followCamera = _instantiator.InstantiatePrefabForComponent<FollowCamera>(prefab, _gameRoot);
        
        var followCameraConfig = _staticDataService.GetGameConfig().PlayerConfig.FollowCameraConfig;
        
        followCamera.Initialize(followCameraConfig);
        followCamera.SetTarget(followTarget);
    }
}