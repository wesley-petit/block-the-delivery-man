using UnityEngine;

public class WallAvoidance : MonoBehaviour, ISteeringBehavior
{
    [SerializeField] private float _force = 5.0f;
    [SerializeField] private float[] _sensorsAngleInDegrees = new []{0.0f, 45.0f, -45.0f};
    [SerializeField] private float _sensorLength = 2.5f;
    [SerializeField] private LayerMask _obstacleLayer;

    public Optional<Vector3> ComputeHeading()
    {
        Optional<Vector3> avoidanceSum = new Optional<Vector3>();

        foreach (var angleInDegree in _sensorsAngleInDegrees)
        {
            var sensorDirection = Helpers.DirFromAngle(angleInDegree, transform);
            var ray = new Ray(transform.position, sensorDirection);
            
            if (Physics.Raycast(ray, out var hit, _sensorLength, _obstacleLayer))
            {
                var avoidDirection = Vector3.Reflect(sensorDirection, hit.normal);
                avoidDirection.Normalize();
                avoidDirection.y = 0f;

                var avoidance = _force * avoidDirection;
                if (avoidanceSum.HasValue)
                    avoidance += avoidanceSum.Value;

                avoidanceSum = new Optional<Vector3>(avoidance);
            }
        }

        return avoidanceSum;
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
