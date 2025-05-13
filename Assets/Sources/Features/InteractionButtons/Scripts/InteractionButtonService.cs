using System;
using Cysharp.Threading.Tasks;

public class InteractionButtonService : IInteractionButtonService
{
    private readonly IHudFactory _hudFactory;

    public InteractionButtonService(IHudFactory hudFactory)
    {
        _hudFactory = hudFactory;
    }

    public async UniTask<InteractionButton> Show(InteractionButtonType type, Action onClick) => 
        await _hudFactory.CreateInteractionButton(type, onClick);
}