using UnityEngine;
using System.Collections.Generic;

public class PathController : MonoBehaviour
{
    [SerializeField] private bool _bUseDijsktra = true;
    [SerializeField] private Grid _grid;
    [SerializeField] private GameState _gameState;
    [SerializeField] private Color _pathColor;

    private List<Node> _path = new();
    private Node _currentTarget;
    
    private Pathfinding _pathfinding;

    private void Awake()
    {
        SelectPathfindingAlgorithm();
        _currentTarget = GetStartNode();
        ComputeShortestPath();
    }

    public void ComputeShortestPath()
    {
        _path = _pathfinding.GetShortestPath(in _currentTarget, in _gameState.EndNode);
    }
    
    public Node GetStartNode() => _gameState.StartNode;

    public Node GetNextTarget()
    {
        if (_path is { Count: > 0 })
        {
            Draw(_path);

            _currentTarget = _path[0];
            _path.RemoveAt(0);
            return _currentTarget;
        }

        return null;
    }
    
    public void Draw(List<Node> path)
    {
        foreach (var current in _grid.Graph.Values)
        {
            current.ResetColor();
        }

        foreach (var n in path)
        {
            n.ChangeColor(_pathColor);
        }
    }

    public void SelectPathfindingAlgorithm()
    {
        if (_bUseDijsktra)
        {
            _pathfinding = new Dijkstra(_grid);
        }
        else
        {
            _pathfinding = new AStar(_grid);
        }
    }
}
