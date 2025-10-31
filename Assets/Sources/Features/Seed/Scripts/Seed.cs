using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Seed : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out CropTile cropTile))
        {
            if (cropTile.CropTileState == CropTileState.Empty)
                cropTile.Sow().Forget();
        }
    }
}