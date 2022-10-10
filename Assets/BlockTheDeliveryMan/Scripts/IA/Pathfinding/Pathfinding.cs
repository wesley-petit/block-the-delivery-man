using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Define an algorithm of finding the shortest path in a graph with positive cost
/// </summary>
public abstract class Pathfinding
{
	/// <summary>
	/// Search the shortest path between start and end vertex from a given graph.
	/// </summary>
	/// <param name="start"></param>
	/// <param name="end"></param>
	/// <param name="graph"></param>
	public abstract List<Vertex> GetShortestPath(in Vertex start, in Vertex end, in Graph graph);

	/// <summary>
	/// If any, return a path of vertex from start to end
	/// </summary>
	/// <param name="start">Edge which will stop the path construction</param>
	/// <param name="end">Edge use as end in the path</param>
	protected List<Vertex> ConstructPath(in Vertex start, in Vertex end)
	{
		List<Vertex> path = new();
		Vertex temp = end;
    
		while (temp != start)
		{
			if (!temp)
			{
				Debug.LogError("No path available.");
				path.Clear();
				break;
			}
			path.Add(temp);
			temp = temp.Predecessor;
		}

		path.Reverse();
		return path;
	}
}
