using UnityEngine;

public class CropTile : MonoBehaviour
{
    public bool Empty { get; private set; } = true;

    public void Sow()
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = transform.position;
        
        Empty = false;
    }
}