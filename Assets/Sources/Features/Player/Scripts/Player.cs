using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HarvestAbility _harvestAbility;
    
    public void Initialize(PlayerConfig playerConfig) => 
        _harvestAbility.SetConfig(playerConfig.HarvestAbilityConfig);
}
