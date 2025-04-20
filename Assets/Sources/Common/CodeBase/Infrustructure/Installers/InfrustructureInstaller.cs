using Zenject;

public class InfrastructureInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindStaticDataService();
        BindAssetProvider();
        BindSceneLoader();
        BindFactories();
        BindInputService();
    }

    private void BindStaticDataService()
    {
        Container.Bind<IStaticDataService>()
            .To<StaticDataService>()
            .AsSingle();
    }

    private void BindInputService()
    {
        Container.BindInterfacesTo<JoystickInput>()
            .AsSingle();
        
        Container.Bind<IInputService>()
            .To<MobileInput>()
            .AsSingle();
    }

    private void BindAssetProvider()
    {
        Container.Bind<IAssetProvider>()
            .To<AssetProvider>()
            .AsSingle();
    }
    
    private void BindFactories()
    {
        Container.Bind<GameStateFactory>()
            .AsSingle();

        Container.Bind<IHudFactory>()
            .To<HudFactory>()
            .AsSingle();
    }

    private void BindSceneLoader()
    {
        Container.Bind<SceneLoader>()
            .AsSingle()
            .WithArguments(this);
    }
}