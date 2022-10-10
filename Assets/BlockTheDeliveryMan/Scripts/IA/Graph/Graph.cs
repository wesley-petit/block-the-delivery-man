using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Store all vertex and search their neighbors
/// </summary>
public class Graph
{
	public Graph() => Vertex = new();
	public Graph(Dictionary<Vector3, Vertex> allVertex) => Vertex = allVertex;

	private Dictionary<Vector3, Vertex> Vertex { get; }
	public static float GAP_BETWEEN_EDGE { get; set; }

	/// <summary>
	/// Find all neighbors around a given position
	/// </summary>
	/// <param name="current">Vertex use as a reference to determine his neighbors</param>
	public List<Vertex> GetNeighbors(Vertex current)
	{
		List<Vertex> neighbors = new();

		foreach (var directionVector in DirectionPattern.NeighborDirections)
		{
			Vector3 searchPosition = current.GetPosition + directionVector * GAP_BETWEEN_EDGE;

			if (Vertex.ContainsKey(searchPosition))
			{
				Vertex currentNeighbor = Vertex[searchPosition];
				neighbors.Add(currentNeighbor);
			}
		}

		return neighbors;
	}

	/// <summary>
	///	Return a list of all vertex in the graph
	/// </summary>
	public List<Vertex> GetVertex() => new(Vertex.Values);
}
