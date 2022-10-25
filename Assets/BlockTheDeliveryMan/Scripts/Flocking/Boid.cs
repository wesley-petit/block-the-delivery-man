using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boid : MonoBehaviour
{
    [SerializeField] private FieldOfView _fov;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _rotationSpeed = 20.0f;
    
    public Vector3 GetPosition => _thisTransform.position;
    public Vector3 Heading { get; private set; }
    private BoidManager _boidManager;

    private IScanReceiver[] _scanReceivers;
    private ISteeringBehavior[] _steeringBehaviors;
    private Transform _thisTransform;
    
    private void Awake()
    {
        _thisTransform = transform;
        _scanReceivers = GetComponents<IScanReceiver>();
        _steeringBehaviors = GetComponents<ISteeringBehavior>();
    }

    private void Start()
    {
        var rand = Random.insideUnitSphere;
        rand.y = 0f;
        Heading = rand;
    }

    private void Update()
    {
        SendScan(Scan());
        ComputeAllHeading();
        
        if (Heading != Vector3.zero)
        {
            ApplyHeading();
        }
        _thisTransform.position += Time.deltaTime * _speed * _thisTransform.forward;
    }

    public void Init(BoidManager boidManager)
    {
        _boidManager = boidManager;
    }

    private List<Boid> Scan()
    {
        List<Boid> visibleTarget = new List<Boid>();
        foreach (var b in _boidManager.Boids)
        {
            if (b == this)
                continue;
            
            if (_fov.IsVisible(this, b))
            {
                // Debug.Log("Name : " + b.name + " - Distance : " + Vector3.Distance(GetPosition, b.GetPosition));
                // Debug.DrawLine(GetPosition, b.GetPosition, Color.green);
                visibleTarget.Add(b);
            }
            else
            {
                // Debug.DrawLine(GetPosition, b.GetPosition, Color.red);
            }
        }

        return visibleTarget;
    }

    private void SendScan(in List<Boid> crowds)
    {
        foreach (var receiver in _scanReceivers) 
            receiver.OnScanReceive(crowds);
    }

    private void ComputeAllHeading()
    {
        foreach (var current in _steeringBehaviors)
        {
            var temp = current.ComputeHeading();
            if (temp.HasValue)
            {
                Heading += temp.Value;
            }
        }
    }

    private void ApplyHeading()
    {
        Heading = Vector3.ClampMagnitude(Heading, 359.0f);
        var headingInQuaternion = Quaternion.LookRotation(Heading);
            
        Quaternion rotation = Quaternion.Slerp(
            _thisTransform.rotation,
            headingInQuaternion, 
            _rotationSpeed * Time.deltaTime);
        Debug.Log(_rotationSpeed * Time.deltaTime);
        _thisTransform.rotation = rotation;
    }
}
