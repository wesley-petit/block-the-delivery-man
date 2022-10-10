using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Implementation of A* in the search of shortest path
/// </summary>
public class AStar : Pathfinding
{
    public override List<Vertex> GetShortestPath(in Vertex start, in Vertex end, in Graph graph)
    {
        // Hash Set collections avoid duplicate management
        HashSet<Vertex> visited = new();
        HashSet<Vertex> notVisited = new();
    
        notVisited.Add(start);

        while (0 < notVisited.Count)
        {
            // Select an vertex with the lowest cost and that has not been visited
            Vertex nearestVertex = notVisited.OrderBy(k => k.GetTotalCosts).First();

            notVisited.Remove(nearestVertex);
            visited.Add(nearestVertex);

            if (nearestVertex == end)
                return ConstructPath(in start, in end);

            // Update cost of near by nodes
            foreach (var neighbor in graph.GetNeighbors(nearestVertex))
            {
                if (visited.Contains(neighbor))
                    continue;
                
                if (!neighbor.IsReachable)
                    continue;

                // Estimate cost from start to end using neighbor. We use 3 values :
                // Cost from start to previous vertex, previous vertex to the current neighbor
                // and finally, an estimate cost or distance between neighbor and end.
            
                // We use an heuristic to determine a direction and maximise the chance of finding the shortest path.
                float estimateCost = nearestVertex.RealCost + neighbor.GraphCost + CalculateHeuristic(neighbor, end);
                if (!notVisited.Contains(neighbor) || estimateCost < neighbor.GetTotalCosts)
                {
                    neighbor.RealCost = nearestVertex.RealCost + neighbor.GraphCost;
                    neighbor.HeuristicCost = CalculateHeuristic(neighbor, end);
                    neighbor.Predecessor = nearestVertex;

                    notVisited.Add(neighbor);
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Returns the result of an heuristic between a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public float CalculateHeuristic(in Vertex a, Vertex b) => Vector3.Distance(a.GetPosition, b.GetPosition);
}
