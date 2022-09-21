using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeCouples
{
    public Node Predecessor;
    public float Cost;

    public NodeCouples(Node predecessor, float cost)
    {
        Predecessor = predecessor;
        Cost = cost;
    }
}

public class Dijkstra : MonoBehaviour
{
    //TODO Remplacer le graph par un vrai graph
    //TODO Convertir un graphe en matrice et inversement
    public void GetShortestPath(Node start, Node end, Dictionary<Vector3, Node> graph)
    {
        Dictionary<Node, NodeCouples> nodecouplesByNodes = new Dictionary<Node, NodeCouples>();
        List<Node> nodeNotVisited = new List<Node>();

        foreach (Node node in graph.Values)
        {
            nodecouplesByNodes.Add(node, new NodeCouples(null, Mathf.Infinity));
            nodeNotVisited.Add(node);
        }

        nodecouplesByNodes[start].Cost = 0f;

        while (nodeNotVisited.Count != 0)
        {
            Node nearestNode = nodecouplesByNodes.OrderByDescending(k => k.Value).Where(k => nodeNotVisited.Contains(k.Key)).First().Key;
            nodeNotVisited.Remove(nearestNode);

            foreach (var currentNeighbor in nearestNode.Neighbors)
            {
                float distanceFromStartNode = nodecouplesByNodes[nearestNode].Cost + Vector3.Distance(nearestNode.Position, nearestNode.Position);
                if (distanceFromStartNode < nodecouplesByNodes[currentNeighbor].Cost)
                {
                    nodecouplesByNodes[currentNeighbor].Cost = distanceFromStartNode;
                }
            }

            if (nearestNode == end)
            {
                break;
            }
        }

        Stack<NodeCouples> path = new Stack<NodeCouples>();
        Node current = end;
        while (current != start)
        {
            path.Push(nodecouplesByNodes[current]);
            current = nodecouplesByNodes[current].Predecessor;
        }
    }
}
