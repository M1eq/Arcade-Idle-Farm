using UnityEngine;

public class CropZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SowAbility sowAbility)) 
            sowAbility.Apply();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SowAbility sowAbility)) 
            sowAbility.Stop();
    }
}
