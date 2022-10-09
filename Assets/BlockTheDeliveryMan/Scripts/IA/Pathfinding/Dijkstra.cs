using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Dijkstra : Pathfinding
{
    public override List<Edge> GetShortestPath(in Edge start, in Edge end, in Graph graph)
    {
        List<Edge> notVisited = new List<Edge>();
        List<Edge> edges = graph.GetEdges();
        
        // Reset all cost and path previously made
        foreach (Edge e in edges)
        {
            e.RealCost = Mathf.Infinity;
            e.Predecessor = null;
            notVisited.Add(e);
        }
        start.RealCost = 0f;

        // Search the shortest path
        while (0 < notVisited.Count)
        {
            // Select an edge with the lowest cost and that has not been visited
            Edge nearestEdge = edges.OrderBy(k => k.RealCost).First(k => notVisited.Contains(k));
            notVisited.Remove(nearestEdge);

            // Update cost of all neighbors with the shortest path at this moment
            foreach (var neighbor in graph.GetNeighbors(nearestEdge))
            {
                float currentCost = nearestEdge.RealCost + neighbor.GraphCost;
                if (currentCost < neighbor.RealCost)
                {
                    neighbor.RealCost = currentCost;
                    neighbor.Predecessor = nearestEdge;
                }
            }

            if (nearestEdge == end) { break; }
        }

        return ConstructPath(start, end);
    }
}
