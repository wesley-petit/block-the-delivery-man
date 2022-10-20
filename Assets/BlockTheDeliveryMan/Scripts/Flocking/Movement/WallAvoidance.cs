using UnityEngine;

public class WallAvoidance : MonoBehaviour, ISteeringBehavior
{
    [SerializeField] private float _force = 5.0f;
    [SerializeField] private float[] _sensorsAngleInDegrees = new []{0.0f, 45.0f, -45.0f};
    [SerializeField] private float _sensorLength = 2.5f;
    [SerializeField] private LayerMask _obstacleLayer;

    private Boid _boid;
    
    private void Awake() => _boid = GetComponent<Boid>();

    public Optional<Vector3> ComputeHeading()
    {
        Optional<Vector3> nearestHit = default;
        float smallestDistance = float.MaxValue;
        
        foreach (var angleInDegree in _sensorsAngleInDegrees)
        {
            var sensorDirection = Helpers.DirFromAngle(angleInDegree, transform);
            var ray = new Ray(transform.position, sensorDirection);
            
            if (Physics.Raycast(ray, out var hit, _sensorLength, _obstacleLayer) && hit.distance < smallestDistance)
            {
                smallestDistance = hit.distance;

                var avoidDirection = Vector3.Reflect(_boid.Heading, hit.normal);
                avoidDirection.Normalize();
                avoidDirection.y = 0f;
                nearestHit = new Optional<Vector3>(_force * avoidDirection);
            }
        }

        return nearestHit;
    }

    private void OnDrawGizmosSelected()
    {
        var ownerTransform = transform;
        foreach (var sensorAngleInDegrees in _sensorsAngleInDegrees)
        {
            var sensorDirection = Helpers.DirFromAngle(sensorAngleInDegrees, ownerTransform);
            
            Gizmos.color = Color.black;
            var position = transform.position;
            Gizmos.DrawLine(position, position + sensorDirection * _sensorLength);
        }
    }
}
