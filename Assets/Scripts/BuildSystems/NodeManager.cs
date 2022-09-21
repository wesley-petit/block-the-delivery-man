using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
	[SerializeField] private float _distanceBetweenEachNodes = 5f;

	private readonly Dictionary<Vector3, Node> _nodes = new Dictionary<Vector3, Node>();

	private void Awake()
	{
		StoreAllNodes();
		NeighborsRegister();
	}

	private void StoreAllNodes()
	{
		Node[] temp = FindObjectsOfType(typeof(Node)) as Node[];

		foreach (var nodeTemp in temp)
		{
			_nodes.Add(nodeTemp.Position, nodeTemp);
		}
	}

	private void NeighborsRegister()
	{
		foreach (var node in _nodes.Values)
		{
			node.Neighbors = GetNeighborsNode(node.Position);
		}
	}

	private Node[] GetNeighborsNode(Vector3 nodePosition)
	{
		Node[] neighbors = new Node[DirectionToVector.ALL_DIRECTIONS.Length];

		foreach (var directionVector in DirectionToVector.ALL_DIRECTIONS)
		{
			Vector3 searchPosition = nodePosition + directionVector.Position * _distanceBetweenEachNodes;
			Direction searchDirection = directionVector.Direction;

			if (_nodes.ContainsKey(searchPosition))
			{
				Node currentNeighbor = _nodes[searchPosition];
				neighbors[(int)searchDirection] = currentNeighbor;
			}
		}

		return neighbors;
	}
}
