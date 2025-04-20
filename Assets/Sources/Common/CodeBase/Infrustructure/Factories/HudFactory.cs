using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class HudFactory : IHudFactory
{
    private readonly IInstantiator _instantiator;
    private readonly IAssetProvider _assetProvider;

    private Transform _hudRoot;

    public HudFactory(IInstantiator instantiator, IAssetProvider assetProvider)
    {
        _instantiator = instantiator;
        _assetProvider = assetProvider;
    }

    public async UniTask CreateHudRoot()
    {
        GameObject root = await _assetProvider.Instantiate(AssetPath.UIRoot);
        _hudRoot = root.transform;
    }

    public async UniTask CreateJoystick()
    {
        GameObject prefab = await _assetProvider.Load<GameObject>(AssetPath.Joystick);

        var mainMenuFacade = _instantiator
            .InstantiatePrefabForComponent<Joystick>(prefab, _hudRoot);
        
        mainMenuFacade.transform.SetAsLastSibling();
    }
}