using UnityEngine;

/// <summary>
/// Gather all boids near by to form a group
/// </summary>
public class AttractMovement : FlokingMovement
{
    protected override void Awake()
    {
        base.Awake();
    }
    
    /// <summary>
    /// Get direction to the center of mass of a crowd
    /// </summary>
    /// <returns></returns>
    public override Optional<Vector3> ComputeHeading()
    {
        if (_crowdsVisible.Count <= 0)
            return default;

        Vector3 centerOfMass = Vector3.zero;

        // Calculate the center of mass
        foreach (var boid in _crowdsVisible)
        {
            centerOfMass += boid.GetPosition;
        }
        centerOfMass /= _crowdsVisible.Count;
        
        centerOfMass -= _boidOwner.GetPosition;
        centerOfMass.Normalize();

        return (Optional<Vector3>)(centerOfMass * _force);
    }
}
