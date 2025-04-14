using UnityEngine;
using Zenject;

public class StateMachineInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindGameStates();
        BindGameStateMachine();
    }

    private void BindGameStates()
    {
        Container.Bind<BootstrapState>()
            .AsSingle();
    }

    private void BindGameStateMachine()
    {
        Container.BindInterfacesTo<GameStateMachine>()
            .AsSingle();
    }
}