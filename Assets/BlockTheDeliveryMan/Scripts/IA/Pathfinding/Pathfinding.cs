using System.Collections.Generic;
using UnityEngine;

public abstract class Pathfinding
{
	protected readonly Grid _grid;

	protected Pathfinding(Grid grid) => _grid = grid;
	
	public abstract List<Node> GetShortestPath(in Node start, in Node end);
	
	// Retrace path when reaching end node at the end of Pathfinding
	protected List<Node> ConstructPath(in Node start, in Node end)
	{
		List<Node> path = new();
		Node temp = end;
        
		while (temp != start)
		{
			if (!temp)
			{
				Debug.LogWarning("No path available.");
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
