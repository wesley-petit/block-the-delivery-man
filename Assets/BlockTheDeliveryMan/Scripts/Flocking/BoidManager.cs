using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoidManager : MonoBehaviour
{
    [SerializeField] private Boid _original;
    [SerializeField] private float _spawnRadius = 10.0f;
    [SerializeField] private int _cloneQuantity = 10;

    public List<Boid> Boids { get; } = new();
    
    private Transform _parent;
    
    private void Awake()
    {
        _parent = transform;
        CreateClones(_cloneQuantity);
    }

    private void CreateClones(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            var clone = Instantiate(_original, GetRandomPosition(), Quaternion.identity, _parent);
            clone.name = $"{_original.name}_{i}";
            
            clone.Init(this);
            Boids.Add(clone);
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 position;
        int numCollider;
        do
        {
            Vector2 randPos = Random.insideUnitCircle * _spawnRadius;
            position = new Vector3(randPos.x, 1.0f, randPos.y);

            numCollider = Physics.OverlapSphereNonAlloc(position, 0.75f, new Collider[1]);
        } while (0 < numCollider);

        return position;
    }
}
