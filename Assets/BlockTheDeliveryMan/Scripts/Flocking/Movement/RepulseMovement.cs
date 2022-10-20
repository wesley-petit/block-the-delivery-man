using UnityEngine;

/// <summary>
/// Avoid collisions between boid
/// </summary>
public class RepulseMovement : FlokingMovement
{
    protected override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// Get the opposite direction of a crowd
    /// </summary>
    /// <returns></returns>
    public override Optional<Vector3> ComputeHeading()
    {
        if (_crowdsVisible.Count <= 0)
            return default;
        
        Vector3 oppositeDirection = Vector3.zero;
        foreach (var boid in _crowdsVisible)
            oppositeDirection += _boidOwner.GetPosition - boid.GetPosition;
        
        oppositeDirection.Normalize();
        
        return (Optional<Vector3>)(oppositeDirection * _force);
    }
}