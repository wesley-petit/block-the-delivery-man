using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Store all edges and search their neighbors
/// </summary>
public class Graph
{
	public Graph() => Edges = new();
	public Graph(Dictionary<Vector3, Edge> allEdges) => Edges = allEdges;

	private Dictionary<Vector3, Edge> Edges { get; }
	public static float GAP_BETWEEN_EDGE { get; set; }

	/// <summary>
	/// Find all neighbors around a given position
	/// </summary>
	/// <param name="current">Edge use as a reference to determine his neighbors</param>
	public List<Edge> GetNeighbors(Edge current)
	{
		List<Edge> neighbors = new();

		foreach (var directionVector in DirectionPattern.NeighborDirections)
		{
			Vector3 searchPosition = current.GetPosition + directionVector * GAP_BETWEEN_EDGE;

			if (Edges.ContainsKey(searchPosition))
			{
				Edge currentNeighbor = Edges[searchPosition];
				neighbors.Add(currentNeighbor);
			}
		}

		return neighbors;
	}

	/// <summary>
	///	Return a list of all edges in the graph
	/// </summary>
	public List<Edge> GetEdges() => new(Edges.Values);
}
