using UnityEngine;
using System.Collections.Generic;

// Store all nodes and search neighbors
public class Grid : MonoBehaviour
{
	[SerializeField] private float _gapBetweenEachNodes = 5f;

	public readonly Dictionary<Vector3, Node> Graph = new();

	private void Awake() => FindAndStoreAllNodes();

	// Get all nodes around a given position
	public List<Node> GetNeighborsFrom(Vector3 position)
	{
		List<Node> neighbors = new();

		foreach (var directionVector in DirectionLibrary.ALL_DIRECTIONS)
		{
			Vector3 searchPosition = position + directionVector * _gapBetweenEachNodes;
			
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
