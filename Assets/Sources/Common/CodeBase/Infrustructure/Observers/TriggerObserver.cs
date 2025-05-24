using UnityEngine;
using UnityEngine.Events;

public class TriggerObserver : MonoBehaviour
{
    public event UnityAction<Collider> TriggerEnter; 
    public event UnityAction<Collider> TriggerStay;
    public event UnityAction<Collider> TriggerExit;
    
    private void OnTriggerEnter(Collider other) => 
        TriggerEnter?.Invoke(other);

    private void OnTriggerStay(Collider other) => 
        TriggerStay?.Invoke(other);

    private void OnTriggerExit(Collider other) => 
        TriggerExit?.Invoke(other);
}
