using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Dijkstra : Pathfinding
{
    public override List<Vertex> GetShortestPath(in Vertex start, in Vertex end, in Graph graph)
    {
        List<Vertex> notVisited = new List<Vertex>();
        List<Vertex> vertex = graph.GetVertex();
        
        // Reset all cost and path previously made
        foreach (Vertex v in vertex)
        {
            v.RealCost = Mathf.Infinity;
            v.Predecessor = null;
            
            if (!v.IsReachable)
                continue;
            
            notVisited.Add(v);
        }
        start.RealCost = 0f;

        // Search the shortest path
        while (0 < notVisited.Count)
        {
            // Select an vertex with the lowest cost and that has not been visited
            Vertex nearestVertex = vertex.OrderBy(k => k.RealCost).First(k => notVisited.Contains(k));
            notVisited.Remove(nearestVertex);

            // Update cost of all neighbors with the shortest path at this moment
            foreach (var neighbor in graph.GetNeighbors(nearestVertex))
            {
                if (!neighbor.IsReachable)
                    continue;
                
                float currentCost = nearestVertex.RealCost + neighbor.GraphCost;
                if (currentCost < neighbor.RealCost)
                {
                    neighbor.RealCost = currentCost;
                    neighbor.Predecessor = nearestVertex;
                }
            }

            if (nearestVertex == end) { break; }
        }

        return ConstructPath(start, end);
    }
}
