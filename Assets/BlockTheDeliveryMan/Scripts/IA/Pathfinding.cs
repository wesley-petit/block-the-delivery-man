using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
	// private readonly Queue<Node> _path = new Queue<Node>();
	//
	// public Node GetTargetNode
	// {
	// 	get
	// 	{
	// 		if (0 < _path.Count)
	// 		{
	// 			return _path.Dequeue();
	// 		}
	//
	// 		return null;
	// 	}
	// }
	//
	// public void CreatePath(Node start, Node end, Node previous = null)
	// {
	// 	_path.Clear();
	// 	Node current = start;
	// 	Node[] validTarget;
	//
	// 	_path.Enqueue(start);
	//
	// 	while (current != end)
	// 	{
	// 		validTarget = GetValidTarget(current.Neighbors, previous);
	// 		previous = current;
	// 		current = GetShortest(validTarget, end);
	//
	// 		if (!current)
	// 		{
	// 			_path.Clear();
	// 			Debug.LogError("There is no issue.");
	// 			break;
	// 		}
	//
	// 		_path.Enqueue(current);
	// 	}
	// }
	//
	// private Node GetShortest(Node[] validTarget, Node end)
	// {
	// 	double minDistanceToTarget = Mathf.Infinity;
	// 	double temp;
	//
	// 	Node nextTarget = null;
	//
	// 	foreach (var neighbor in validTarget)
	// 	{
	// 		if (!neighbor) { continue; }
	//
	// 		temp = Vector3.Distance(neighbor.Position, end.Position);
	//
	// 		if (temp < minDistanceToTarget)
	// 		{
	// 			minDistanceToTarget = temp;
	// 			nextTarget = neighbor;
	// 		}
	// 	}
	//
	// 	return nextTarget;
	// }
	//
	// private Node[] GetValidTarget(Node[] neighbors, Node previousNode)
	// {
	// 	Node[] validNeighbors = new Node[neighbors.Length];
	//
	// 	for (int i = 0; i < neighbors.Length; i++)
	// 	{
	// 		Node testingNode = neighbors[i];
	// 		if (!testingNode) { continue; }
	// 		//if (testingNode.Occupied) { continue; }
	// 		if (testingNode == previousNode) { continue; }
	//
	// 		validNeighbors[i] = testingNode;
	// 	}
	//
	// 	return validNeighbors;
	// }
}
