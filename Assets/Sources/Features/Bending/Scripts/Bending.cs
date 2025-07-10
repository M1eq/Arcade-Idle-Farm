using UnityEngine;

public class Bending : MonoBehaviour
{
    private BendingConfig _config;

    public void Initialize(BendingConfig config) => 
        _config = config;

    private void Update() => 
        ApplyBending();

    private void ApplyBending()
    {
        foreach (var material in _config.BendingTargets)
            material.SetVector(_config.PositionReference, transform.position);
    }
}
