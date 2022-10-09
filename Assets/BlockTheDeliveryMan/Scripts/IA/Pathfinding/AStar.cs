using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Implementation of A* in the search of shortest path
/// </summary>
public class AStar : Pathfinding
{
    public override List<Edge> GetShortestPath(in Edge start, in Edge end, in Graph graph)
    {
        // Hash Set collections avoid duplicate management
        HashSet<Edge> visited = new();
        HashSet<Edge> notVisited = new();
    
        notVisited.Add(start);

        while (0 < notVisited.Count)
        {
            // Select an edge with the lowest cost and that has not been visited
            Edge nearestEdge = notVisited.OrderBy(k => k.GetTotalCosts).First();

            notVisited.Remove(nearestEdge);
            visited.Add(nearestEdge);

            if (nearestEdge == end)
                return ConstructPath(in start, in end);

            // Update cost of near by nodes
            foreach (var neighbor in graph.GetNeighbors(nearestEdge))
            {
                if (visited.Contains(neighbor))
                    continue;

                // Estimate cost from start to end node using neighbor. We use 3 values :
                // Cost from start to previous edge, previous edge to the current neighbor
                // and finally, an estimate cost or distance between neighbor and end.
            
                // We use an heuristic to determine a direction and maximise the chance of finding the shortest path.
                float estimateCost = nearestEdge.RealCost + neighbor.GraphCost + CalculateHeuristic(neighbor, end);
                if (!notVisited.Contains(neighbor) || estimateCost < neighbor.GetTotalCosts)
                {
                    neighbor.RealCost = nearestEdge.RealCost + neighbor.GraphCost;
                    neighbor.HeuristicCost = CalculateHeuristic(neighbor, end);
                    neighbor.Predecessor = nearestEdge;

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
    public float CalculateHeuristic(in Edge a, Edge b) => Vector3.Distance(a.GetPosition, b.GetPosition);
}
