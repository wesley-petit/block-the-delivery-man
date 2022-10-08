using UnityEngine;
using System.Collections.Generic;

// Store all nodes and search neighbors
public class Grid : MonoBehaviour
{
	public readonly Dictionary<Vector3, Node> Graph = new();

	private float GAP_BETWEEN_NODE = 5f;

	private void Awake() => FindAndStoreAllNodes();

	// Get all nodes around a given position
	public List<Node> GetNeighborsFrom(Vector3 position)
	{
		List<Node> neighbors = new();

		foreach (var directionVector in DirectionLibrary.ALL_DIRECTIONS)
		{
			Vector3 searchPosition = position + directionVector * GAP_BETWEEN_NODE;

			if (Graph.ContainsKey(searchPosition))
			{
				Node currentNeighbor = Graph[searchPosition];
				neighbors.Add(currentNeighbor);
			}
		}

		return neighbors;
	}

	// If any, get a node by his exact position
	public Node GetNodeByPosition(Vector3 position)
	{
		if (Graph.ContainsKey(position))
			return Graph[position];

		return null;
	}
	
	private void FindAndStoreAllNodes()
	{
		Node[] temp = FindObjectsOfType(typeof(Node)) as Node[];

		foreach (var nodeTemp in temp)
		{
			Graph.Add(nodeTemp.Position, nodeTemp);
		}
	}
}
