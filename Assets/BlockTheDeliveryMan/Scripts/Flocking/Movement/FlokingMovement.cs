using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlokingMovement : MonoBehaviour, IScanReceiver, ISteeringBehavior
{
    [SerializeField] protected float _force = 1f;
    [SerializeField] private FieldOfView _fov;

    protected Boid _boidOwner;
    protected List<Boid> _crowdsVisible = new();

    protected virtual void Awake() => _boidOwner = GetComponent<Boid>();

    public void OnScanReceive(in List<Boid> crowds)
    {
        _crowdsVisible.Clear();
        foreach (var neighbor in crowds)
            if (_fov.IsVisible(_boidOwner, neighbor))
                _crowdsVisible.Add(neighbor);
    }

    public abstract Optional<Vector3> ComputeHeading();
}
