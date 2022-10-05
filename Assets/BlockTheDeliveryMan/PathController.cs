using System;
using UnityEngine;
using System.Collections.Generic;

public class PathController : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private Dijkstra _pathfinding;
    [SerializeField] private Color _pathColor;
    [SerializeField] private Color[] _pathProfile = Array.Empty<Color>();
    
    public Node GetStartNode() => _gameState.StartNode;

    public Node GetNextTarget(Node currentTarget)
    {
        List<Node> path = _pathfinding.GetShortestPath(currentTarget, _gameState.EndNode);

        Draw(path);
        
        if (path != null && 0 < path.Count)
        {
            return path[0];
        }

        return null;
    }
    
    public void Draw(List<Node> path)
    {
        Grid grid = FindObjectOfType<Grid>();
        
        foreach (var current in grid.Graph.Values)
        {
            current.ResetColor();
        }

        foreach (var n in path)
        {
            n.ChangeColor(_pathColor);
        }
    }
}
