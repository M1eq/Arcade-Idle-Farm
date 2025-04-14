using Zenject;

public class InfrastructureInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindAssetProvider();
        BindSceneLoader();
        BindFactories();
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
    }

    private void BindSceneLoader()
    {
        Container.Bind<SceneLoader>()
            .AsSingle()
            .WithArguments(this);
    }
}