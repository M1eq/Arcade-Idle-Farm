using System;
using Cysharp.Threading.Tasks;

public interface IHudFactory
{
    UniTask CreateHudRoot();
    UniTask CreateJoystick();
    UniTask<InteractionButton> CreateInteractionButton(InteractionButtonType type, Action clickReaction);
}