using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IHudFactory
{
    UniTask CreateHudRoot();
    UniTask CreateJoystick();
    UniTask CreateInventoryHud();
    UniTask<WalletHudHolder> CreateWalletHud();
    UniTask<InteractionButton> CreateInteractionButton(InteractionButtonType type, Action clickReaction);
    UniTask<ItemCell> CreateItemCell(PlantType plantType, Transform parent);
}