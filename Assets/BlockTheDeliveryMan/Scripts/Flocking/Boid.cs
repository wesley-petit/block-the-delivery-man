using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boid : MonoBehaviour
{
    [SerializeField] private FieldOfView _fov;
    [SerializeField] private float _maxDirection = 1.0f;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _rotationSpeed = 20.0f;
    
    public Vector3 GetPosition => _thisTransform.position;
    public Vector3 Heading { get; private set; }

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

        foreach (var current in _steeringBehaviors)
        {
            var temp = current.ComputeHeading();
            if (temp.HasValue)
            {
                Heading += temp.Value;
            }
        }
        
        // if (_maxDirection < Mathf.Abs(_direction.x) || _maxDirection < Mathf.Abs(_direction.z))
        // {
        //     float scaleFactor = _maxDirection / Mathf.Max(_direction.x, _direction.z);
        //     _direction *= scaleFactor;
        // }
        
        if (Heading != Vector3.zero)
        {
            Heading = Vector3.ClampMagnitude(Heading, 360);
            var headingInQuaternion = Quaternion.LookRotation(Heading);
            
            Quaternion rotation = Quaternion.Slerp(
                _thisTransform.rotation,
                headingInQuaternion, 
                _rotationSpeed * Time.deltaTime);
            
            _thisTransform.rotation = rotation;
        }
        
        _thisTransform.position += Time.deltaTime * _speed * _thisTransform.forward;
    }

    private List<Boid> Scan()
    {
        Boid[] boids = FindObjectsOfType<Boid>();

        List<Boid> visibleTarget = new List<Boid>();
        foreach (var b in boids)
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
}
