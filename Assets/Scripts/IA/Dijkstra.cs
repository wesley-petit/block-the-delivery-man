using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Dijkstra : MonoBehaviour
{
    [SerializeField] private Grid _grid = null;
    
    // TODO Prendre en compte s'il n'y a pas de chemin possible
    public List<Node> GetShortestPath(Node start, Node end)
    {
        List<Node> nodeNotVisited = new List<Node>();

        // Reset all cost and path previously made
        foreach (Node node in _grid.Graph.Values)
        {
            node.Cost = Mathf.Infinity;
            node.Predecessor = null;

            // Visit only node available
            if (!node.Occupied)
            {
                nodeNotVisited.Add(node);
            }
        }
        start.Cost = 0f;

        // Search the shortest path
        while (nodeNotVisited.Count != 0)
        {
            // Select a node with the lowest cost and that has not been visited
            Node nearestNode = _grid.Graph
                .OrderBy(k => k.Value.Cost).First(k => nodeNotVisited.Contains(k.Value)).Value;
            nodeNotVisited.Remove(nearestNode);

            // Update cost of all neighbors with the shortest path at this moment
            foreach (var neighbor in _grid.GetNeighborsFrom(nearestNode.Position))
            {
                if (neighbor.Occupied) { continue; }
                
                float currentCost = nearestNode.Cost + CalculateCost(nearestNode, neighbor);
                if (currentCost < neighbor.Cost)
                {
                    neighbor.Cost = currentCost;
                    neighbor.Predecessor = nearestNode;
                }
            }

            // Reach the end
            if (nearestNode == end)
            {
                break;
            }
        }

        // Construct the shortest path
        List<Node> path = new();
        Node temp = end;
        while (temp != start)
        {
            path.Add(temp);
            temp = temp.Predecessor;

            if (!temp)
            {
                Debug.LogWarning("No path available.");
                path.Clear();
                break;
            }
        }

        path.Reverse();
        return path;
    }

    public float CalculateCost(Node a, Node b)
    {
        return Vector3.Distance(a.Position, b.Position);
    }
}
