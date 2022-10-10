using UnityEngine;
using System.Collections.Generic;
using Unity.Collections;

/// <summary>
/// Update player path in answer of game events
/// </summary>
public class PathController : MonoBehaviour
{
    [SerializeField] private IntGameEvent onSwitchAlgorithm;
    
    [SerializeField] private EdgeGameEvent onSetupStart;
    [SerializeField] private EdgeGameEvent onSwitchDelivery;
    [SerializeField] private VoidGameEvent onGraphChange;
    
    private Vertex _nextVertex;
    private Vertex _deliveryVertex;

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
    private List<Vertex> _currentPath = new();

    public Graph Graph { get => _graph; set => _graph = value; }

    private void OnEnable()
    {
        onSwitchAlgorithm.RegisterListener(SwitchAlgorithm);
        
        onSwitchDelivery.RegisterListener(SetDelivery);
        onSetupStart.RegisterListener(SetStart);
        onGraphChange.RegisterListener(UpdatePath);
    }

    private void OnDisable()
    {
        onSwitchAlgorithm.UnregisterListener(SwitchAlgorithm);
        
        onSwitchDelivery.UnregisterListener(SetDelivery);
        onSetupStart.UnregisterListener(SetStart);
        onGraphChange.UnregisterListener(UpdatePath);
    }

    private void SwitchAlgorithm(int value)
    {
        if (value == 0)
        {
            _pathfinding = new AStar();
        }
        else
        {
            _pathfinding = new Dijkstra();
        }
        
        ComputeShortestPath();
    }
    
    #region Start and end setters
    private void SetStart(Vertex start)
    {
        if (!_nextVertex)
        {
            _nextVertex = start;
        }

        if (_nextVertex && _deliveryVertex)
        {
            ComputeShortestPath();
        }
    }

    private void SetDelivery(Vertex end)
    {
        _deliveryVertex = end;
        
        if (_nextVertex && _deliveryVertex)
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
        foreach (var node in _graph.GetVertex())
            node.ResetCost();
        
        _currentPath = _pathfinding.GetShortestPath(in _nextVertex, in _deliveryVertex, in _graph);

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

        _nextVertex = _currentPath[0];
        _currentPath.RemoveAt(0);
        return _nextVertex.GetPosition;
    }

    public void TogglePathVisibility()
    {
        _bVisualizePath = !_bVisualizePath;

        if (!_bVisualizePath)
        {
            PathDrawerUtils.ResetPreviousPath(_graph);
        }
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
