using UnityEngine;
using WSWhitehouse.TagSelector;

public class FollowTarget : MonoBehaviour, ISteeringBehavior
{
    [SerializeField] private float _force = 0.5f;
    [SerializeField, TagSelector] private string _targetTag = "CrowdLeader";

    private Transform _target;
    
    private void Awake()
    {
        var go = GameObject.FindGameObjectWithTag(_targetTag);
        if (!go)
        {
            Debug.LogError($"No target available with the tag {_targetTag}");
            return;
        }

        _target = go.transform;
    }
    
    public Optional<Vector3> ComputeHeading()
    {
        if (!_target)
            return new Optional<Vector3>();

        Vector3 directionToTarget = _target.position - transform.position;
        directionToTarget.Normalize();
        directionToTarget.y = 0f;
        
        return (Optional<Vector3>)(directionToTarget * _force);
    }
}
