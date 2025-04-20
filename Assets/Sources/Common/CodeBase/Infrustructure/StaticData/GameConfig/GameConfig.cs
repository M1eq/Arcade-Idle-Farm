using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "StaticData/GameConfig")]
public class GameConfig : ScriptableObject
{
    [field: SerializeField] public JoystickConfig JoystickConfig { get; private set; }
}