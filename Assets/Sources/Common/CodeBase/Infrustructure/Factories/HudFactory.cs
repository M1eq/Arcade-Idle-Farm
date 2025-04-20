using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class HudFactory : IHudFactory
{
    private readonly IInstantiator _instantiator;
    private readonly IAssetProvider _assetProvider;
    private readonly IStaticDataService _staticDataService;

    private Transform _hudRoot;

    public HudFactory(IInstantiator instantiator, IAssetProvider assetProvider, IStaticDataService staticDataService)
    {
        _instantiator = instantiator;
        _assetProvider = assetProvider;
        _staticDataService = staticDataService;
    }

    public async UniTask CreateHudRoot()
    {
        GameObject root = await _assetProvider.Instantiate(AssetPath.UIRoot);
        _hudRoot = root.transform;
    }

    public async UniTask CreateJoystick()
    {
        GameObject prefab = await _assetProvider.Load<GameObject>(AssetPath.Joystick);

        var joystick = _instantiator.InstantiatePrefabForComponent<Joystick>(prefab, _hudRoot);
        var joystickConfig = _staticDataService.GetGameConfig().JoystickConfig;
        
        joystick.Initialize(joystickConfig);
        joystick.transform.SetAsLastSibling();
    }
}