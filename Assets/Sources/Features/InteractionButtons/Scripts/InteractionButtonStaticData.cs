using UnityEngine;

[CreateAssetMenu(fileName = "InteractionButtonStaticData", menuName = "StaticData/InteractionButtonStaticData")]
public class InteractionButtonStaticData : ScriptableObject
{
    [field: SerializeField] public InteractionButtonType ButtonType { get; set; }
    [field: SerializeField] public Sprite Icon { get; set; }
}
