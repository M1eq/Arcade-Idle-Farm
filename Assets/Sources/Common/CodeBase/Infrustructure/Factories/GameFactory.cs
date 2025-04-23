using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameFactory : IGameFactory
{
    private readonly IAssetProvider _assetProvider;
    private readonly IInstantiator _instantiator;
    private readonly IStaticDataService _staticDataService;

    private Transform _playerRoot;
    private Vector3 _playerSpawnPosition;

    public GameFactory(IInstantiator instantiator, IAssetProvider assetProvider, IStaticDataService staticDataService)
    {
        _instantiator = instantiator;
        _assetProvider = assetProvider;
        _staticDataService = staticDataService;
    }

    public async UniTask CreatePlayer()
    {
        GameObject prefab = await _assetProvider.Load<GameObject>(AssetPath.Player);

        var player = _instantiator.InstantiatePrefabForComponent<Player>(prefab, _playerRoot);
        var playerConfig = _staticDataService.GetGameConfig().PlayerConfig;

        var movement = player.GetComponent<PlayerMovement>();
        movement.Initialize(playerConfig.MovementConfig);
        
        var animator = player.GetComponent<PlayerAnimator>();
        animator.Initialize(playerConfig.AnimatorConfig);
        
        player.transform.SetParent(_playerRoot);
        player.transform.position = _playerSpawnPosition;
    }

    public async UniTask CreateLevel()
    {
        GameObject prefab = await _assetProvider.Load<GameObject>(AssetPath.Level);
        
        var level = _instantiator.InstantiatePrefabForComponent<Level>(prefab, _playerRoot);
        
        _playerRoot = level.transform;
        _playerSpawnPosition = level.PlayerSpawnPoint.position;
    }
}