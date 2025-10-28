using Zenject;

public class InfrastructureInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindStaticDataService();
        BindAssetProvider();
        BindSceneLoader();
        BindColorChanger();
        BindFactories();
        BindInputService();
        BindInteractionButtonService();
        BindCollectorService();
        BindInventoryService();
        BindSellService();
        BindWalletService();
        BindProgressService();
    }

    private void BindProgressService()
    {
        Container.Bind<ISerializer>()
            .To<JsonUtilitySerializer>()
            .AsSingle();
        
        Container.Bind<ISaveSystem>()
            .To<SaveSystem>()
            .AsSingle();

        Container.Bind<IGameProgressService>()
            .To<GameProgressService>()
            .AsSingle();
    }
    
    private void BindWalletService()
    {
        Container.BindInterfacesTo<Wallet>()
            .AsSingle();
    }

    private void BindSellService()
    {
        Container.Bind<ISellService>()
            .To<Sell>()
            .AsSingle();
    }

    private void BindInventoryService()
    {
        Container.BindInterfacesTo<Inventory>()
            .AsSingle();
    }

    private void BindCollectorService()
    {
        Container.Bind<ICollector>()
            .To<Collector>()
            .AsSingle();
    }

    private void BindColorChanger()
    {
        Container.Bind<IColorChanger>()
            .To<ColorChanger>()
            .AsSingle();
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
        
        Container.Bind<ISaveDataFactory>()
            .To<SaveDataFactory>()
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

        Container.Bind<IParticleFactory>()
            .To<ParticleFactory>()
            .AsSingle();

        Container.Bind<IItemCellFactory>()
            .To<ItemCellFactory>()
            .AsSingle();
    }

    private void BindSceneLoader()
    {
        Container.Bind<SceneLoader>()
            .AsSingle()
            .WithArguments(this);
    }
}