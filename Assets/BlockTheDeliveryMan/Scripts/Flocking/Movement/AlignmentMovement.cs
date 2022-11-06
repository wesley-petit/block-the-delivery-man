using UnityEngine;

/// <summary>
/// Align a group of boid to follow the same path
/// </summary>
public class AlignmentMovement : FlokingMovement
{
    protected override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// Get average direction from a crowd
    /// </summary>
    /// <returns></returns>
    public override Optional<Vector3> ComputeHeading()
    {
        if (_crowdsVisible.Count <= 0)
            return new Optional<Vector3>();
        
        Vector3 avgHeading = Vector3.zero;
        foreach (var boid in _crowdsVisible)
            avgHeading += boid.Heading;

        avgHeading /= _crowdsVisible.Count;
        avgHeading.Normalize();

        return (Optional<Vector3>)(avgHeading * _force);
    }
}