using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateObjectAtRandomPosition : MonoBehaviour
{
    [SerializeField] private GameObject _original;
    [SerializeField] private float _spawnRadius = 10.0f;
    [SerializeField] private int _cloneQuantity = 10;
    
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
            Vector3 position;
            int numCollider;
            do
            {
                Vector2 randPos = Random.insideUnitCircle * _spawnRadius;
                position = new Vector3(randPos.x, 1.0f, randPos.y);

                numCollider = Physics.OverlapSphereNonAlloc(position, 0.75f, new Collider[1]);
            } while (0 < numCollider);
            
            GameObject clone = Instantiate(_original, position, Quaternion.identity, _parent);
            clone.name = $"{_original.name}_{i}";
        }
    }
}
