using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "StaticData/GameConfig")]
public class GameConfig : ScriptableObject
{
    [field: SerializeField] public JoystickConfig JoystickConfig { get; private set; }
    [field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }
}