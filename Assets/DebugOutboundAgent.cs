using UnityEngine;

public class DebugOutboundAgent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }
}
