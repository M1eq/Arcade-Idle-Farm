using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "StaticData/GameConfig")]
public class GameConfig : ScriptableObject
{
    [field: SerializeField] public JoystickConfig JoystickConfig { get; private set; }
    [field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }
    [field: SerializeField] public CropZoneConfig CropZoneConfig { get; private set; }
    [field: SerializeField] public PlantsSellZoneConfig PlantSellZoneConfig { get; private set; }
    [field: SerializeField] public NewProgressConfig NewProgressConfig { get; private set; }
}