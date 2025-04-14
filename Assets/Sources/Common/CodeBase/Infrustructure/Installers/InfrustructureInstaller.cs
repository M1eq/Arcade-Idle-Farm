using Zenject;

public class InfrastructureInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSceneLoader();
        BindFactories();
    }
    
    private void BindFactories()
    {
        Container.Bind<StateFactory>()
            .AsSingle();
    }

    private void BindSceneLoader()
    {
        Container.Bind<SceneLoader>()
            .AsSingle()
            .WithArguments(this);
    }
}