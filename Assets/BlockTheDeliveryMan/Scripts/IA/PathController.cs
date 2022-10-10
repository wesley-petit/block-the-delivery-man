using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Update player path in answer of game events
/// </summary>
public class PathController : MonoBehaviour
{
    [SerializeField] private EdgeGameEvent onSetupStart;
    [SerializeField] private EdgeGameEvent onSwitchDelivery;
    [SerializeField] private VoidGameEvent onGraphChange;
    
    private Edge _nextEdge;
    private Edge _deliveryEdge;

    /// <summary>
    /// Visualize the shortest path
    /// </summary>
    [SerializeField] private bool _bVisualizePath = true;

    private Graph _graph;
    
    /// <summary>
    /// Algorithm to search the shortest path in a graph
    /// </summary>
    private Pathfinding _pathfinding = new Dijkstra();

    /// <summary>
    /// Result of pathfinding between current and end edge.
    /// </summary>
    private List<Edge> _currentPath = new();

    public Graph Graph { get => _graph; set => _graph = value; }

    private void OnEnable()
    {
        onSwitchDelivery.RegisterListener(SetDelivery);
        onSetupStart.RegisterListener(SetStart);
        onGraphChange.RegisterListener(UpdatePath);
    }

    private void OnDisable()
    {
        onSwitchDelivery.UnregisterListener(SetDelivery);
        onSetupStart.UnregisterListener(SetStart);
        onGraphChange.UnregisterListener(UpdatePath);
    }

    #region Start and end setters
    private void SetStart(Edge start)
    {
        if (!_nextEdge)
        {
            _nextEdge = start;
        }

        if (_nextEdge && _deliveryEdge)
        {
            ComputeShortestPath();
        }
    }

    private void SetDelivery(Edge end)
    {
        _deliveryEdge = end;
        
        if (_nextEdge && _deliveryEdge)
        {
            ComputeShortestPath();
        }
    }
    #endregion

    private void UpdatePath(Void a) => ComputeShortestPath();

    /// <summary>
    /// Compute and store the shortest path
    /// </summary>
    private void ComputeShortestPath()
    {
        // Remove cost from previous path, because it's not up to date.
        foreach (var node in _graph.GetEdges())
            node.ResetCost();
        
        _currentPath = _pathfinding.GetShortestPath(in _nextEdge, in _deliveryEdge, in _graph);

        if (_bVisualizePath && _currentPath != null)
        {
            PathDrawerUtils.Draw(in _graph, in _currentPath);
        }
    }
    
    /// <summary>
    /// If a path has been made and has at least one edge
    /// </summary>
    /// <returns></returns>
    public bool HasAValidPath() => _currentPath is { Count: > 0 };

    /// <summary>
    /// Returns next position from the computed path
    /// </summary>
    /// <returns></returns>
    public Vector3 GetNextTarget()
    {
        if (!HasAValidPath())
        {
            Debug.LogError("Path invalid. Can't determine next target.");
            return Vector3.zero;
        }
            
        if (_bVisualizePath)
        {
            PathDrawerUtils.Draw(in _graph, in _currentPath);
        }

        _nextEdge = _currentPath[0];
        _currentPath.RemoveAt(0);
        return _nextEdge.GetPosition;
    }

    // TEST 
    //private void Awake() => CreateGraph();
    //private void CreateGraph()
    //{
    //    Dictionary<Vector3, Edge> edges = new();
    //    if (FindObjectsOfType(typeof(Edge)) is Edge[] temp)
    //        foreach (var n in temp)
    //            edges.Add(n.GetPosition, n);
    //    Graph = new Graph(edges);
    //}

}
