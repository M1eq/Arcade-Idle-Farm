using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out CropTile cropTile))
        {
            if (cropTile.IsWatered == false)
                cropTile.Water();
        }
    }
}
