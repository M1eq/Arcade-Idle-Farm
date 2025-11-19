using UnityEngine;

public class UniqueID : MonoBehaviour
{
    [field: SerializeField] public string Id { get; private set; }
    
    public void SetId(string id) => Id = id;
}