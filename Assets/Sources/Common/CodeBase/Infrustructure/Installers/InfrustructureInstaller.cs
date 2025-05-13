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
        BindInteractionButtonService();
    }

    private void BindInteractionButtonService()
    {
        Container.Bind<IInteractionButtonService>()
            .To<InteractionButtonService>()
            .AsSingle();
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

        Container.Bind<IGameFactory>()
            .To<GameFactory>()
            .AsSingle();

        Container.Bind<IPlantFactory>()
            .To<PlantFactory>()
            .AsSingle();
    }

    private void BindSceneLoader()
    {
        Container.Bind<SceneLoader>()
            .AsSingle()
            .WithArguments(this);
    }
}