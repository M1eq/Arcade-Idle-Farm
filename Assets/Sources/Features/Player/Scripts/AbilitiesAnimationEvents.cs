using UnityEngine;

public class AbilitiesAnimationEvents : MonoBehaviour
{
    [SerializeField] private ParticleSystem _seedParticle;
    [SerializeField] private Transform _sickle;
    [SerializeField] private LayerMask _mask;

    public void PlaySeedParticle() =>
        _seedParticle.Play();

    public void ApplyHarvestOverlap()
    {
        Collider[] touchedColliders = Physics.OverlapSphere(_sickle.position, 1, _mask);

        foreach (Collider touchedCollider in touchedColliders)
        {
            CropTile cropTile = touchedCollider.GetComponentInParent<CropTile>();

            if (cropTile.IsEmpty == false && cropTile.IsWatered)
                cropTile.Harvest();
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (_sickle == null)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_sickle.position, 1);
    }
}