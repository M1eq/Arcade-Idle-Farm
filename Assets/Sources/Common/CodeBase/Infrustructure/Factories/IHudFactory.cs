using Cysharp.Threading.Tasks;

public interface IHudFactory
{
    UniTask CreateHudRoot();
    UniTask CreateJoystick();
}