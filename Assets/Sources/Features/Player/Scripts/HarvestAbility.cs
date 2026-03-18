using UnityEngine;

public class HarvestAbility : MonoBehaviour, IAbility
{
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private Transform _sickle;
    [SerializeField] private LayerMask _mask;
    
    private HarvestAbilityConfig _config;

    public void Apply() => 
        _animator.LaunchHarvestAnimation();

    public void Stop() => 
        _animator.StopHarvestAnimation();

    public void SetConfig(HarvestAbilityConfig config) => 
        _config = config;

    public void ActivateOverlap()
    {
        Collider[] touchedColliders = Physics.OverlapSphere(_sickle.position, _config.HarvestRadius, _mask);

        foreach (Collider touchedCollider in touchedColliders)
        {
            CropTile cropTile = touchedCollider.GetComponentInParent<CropTile>();

            if (cropTile.CropTileState == CropTileState.Watered)
                cropTile.Harvest();
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (_sickle != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_sickle.position, _config.HarvestRadius);
        }
    }
}
