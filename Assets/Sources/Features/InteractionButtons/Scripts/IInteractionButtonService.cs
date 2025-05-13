using System;
using Cysharp.Threading.Tasks;

public interface IInteractionButtonService
{
    UniTask<InteractionButton> Show(InteractionButtonType type, Action onClick);
}