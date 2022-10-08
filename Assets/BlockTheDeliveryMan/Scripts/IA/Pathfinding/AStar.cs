using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStar : Pathfinding
{
    public AStar(Grid grid) : base(grid) { }
    
    public override List<Node> GetShortestPath(in Node start, in Node end)
    {
        // Hash Set collections avoid duplicate management
        HashSet<Node> nodesVisited = new();
        HashSet<Node> nodesNotVisited = new();
        
        nodesNotVisited.Add(start);

        while (0 < nodesNotVisited.Count)
        {
            // Select a node with the lowest cost and that has not been visited
            Node nearestNode = nodesNotVisited.OrderBy(k => k.EstimateCosts).First();

            nodesNotVisited.Remove(nearestNode);
            nodesVisited.Add(nearestNode);

            if (nearestNode == end)
                return ConstructPath(in start, in end);

            // Update cost of near by nodes
            foreach (var neighbor in _grid.GetNeighborsFrom(nearestNode.Position))
            {
                if (nodesVisited.Contains(neighbor))
                    continue;

                // Estimate cost from start to end node using neighbor. We use 3 values :
                    // Cost from start to nearest Node
                    // Cost from nearest node to neighbor
                    // and finally, an estimate cost or distance between neighbor and end
                float estimateCost = nearestNode.RealCost + neighbor.GraphCost + CalculateHeuristic(neighbor, end);
                if (!nodesNotVisited.Contains(neighbor) || estimateCost < neighbor.EstimateCosts)
                {
                    neighbor.RealCost = nearestNode.RealCost + neighbor.GraphCost;
                    neighbor.HeuristicCost = CalculateHeuristic(neighbor, end);
                    neighbor.Predecessor = nearestNode;

                    nodesNotVisited.Add(neighbor);
                }
            }
        }

        return null;
    }

    // Use to estimate distance between a node and the target
    public float CalculateHeuristic(in Node a, in Node b) => Vector3.Distance(a.Position, b.Position);
}
