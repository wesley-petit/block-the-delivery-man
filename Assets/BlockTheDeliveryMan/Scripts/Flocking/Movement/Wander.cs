using UnityEngine;

public class Wander : MonoBehaviour, ISteeringBehavior
{
    [SerializeField] private float _force = 0.1f;
    
    public Optional<Vector3> ComputeHeading()
    {
        var rand = Random.insideUnitSphere * _force;
        rand.y = 0f;
        
        return (Optional<Vector3>)rand;
    }
}
