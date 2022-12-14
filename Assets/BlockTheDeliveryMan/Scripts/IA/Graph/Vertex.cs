using UnityEngine;

/// <summary>
/// Vertex of a graph with positive costs
/// </summary>
public class Vertex : MonoBehaviour
{
    /// <summary>
    /// Travel cost on the graph from neighbors edges to these current edge
    /// </summary>
    [field: SerializeField, Range(0f, 15f)] public float GraphCost { get; private set; } = 1;

    /// <summary>
    /// Store a positive cost since start position to determine the shortest path
    /// </summary>
    public float RealCost
    {
        get => _realCost;
        set
        {
            // Support only positive cost, because negative costs are not supported by Dijsktra or AStar
            if (value < 0)
            {
                Debug.LogError("A negative Cost has been set.");
                return;
            }                
            _realCost = value;
        }
    }
    private float _realCost;

    /// <summary>
    /// Cost from these vertex to the end
    /// </summary>
    public float HeuristicCost { get; set; }

    public Vertex Predecessor { get; set; }

    public float GetTotalCosts => RealCost + HeuristicCost;
    public Vector3 GetPosition => transform.position;
    
    /// <summary>
    /// Reset all cost previously estimate
    /// </summary>
    public void ResetCost()
    {
        RealCost = 0;
        HeuristicCost = 0;
    }
    
    //TODO Delete
    public bool IsReachable { get; set; } = true;
}
