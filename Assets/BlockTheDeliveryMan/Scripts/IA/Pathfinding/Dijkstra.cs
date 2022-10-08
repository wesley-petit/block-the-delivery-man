using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Dijkstra : Pathfinding
{
    public Dijkstra(Grid grid) : base(grid) { }

    public override List<Node> GetShortestPath(in Node start, in Node end)
    {
        List<Node> nodeNotVisited = new List<Node>(); 
        
        // Reset all cost and path previously made
        foreach (Node node in _grid.Graph.Values)
        {
            node.RealCost = Mathf.Infinity;
            node.Predecessor = null;
            nodeNotVisited.Add(node);
        }
        start.RealCost = 0f;

        // Search the shortest path
        while (0 < nodeNotVisited.Count)
        {
            // Select a node with the lowest cost and that has not been visited
            Node nearestNode = _grid.Graph.Values.OrderBy(k => k.RealCost).First(k => nodeNotVisited.Contains(k));
            nodeNotVisited.Remove(nearestNode);

            // Update cost of all neighbors with the shortest path at this moment
            foreach (var neighbor in _grid.GetNeighborsFrom(nearestNode.Position))
            {
                float currentCost = nearestNode.RealCost + neighbor.GraphCost;
                if (currentCost < neighbor.RealCost)
                {
                    neighbor.RealCost = currentCost;
                    neighbor.Predecessor = nearestNode;
                }
            }

            // Reach the end
            if (nearestNode == end)
            {
                break;
            }
        }

        return ConstructPath(start, end);
    }
}
