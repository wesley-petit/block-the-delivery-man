using System.Collections.Generic;

/// <summary>
/// Draw a given path on a graph
/// </summary>
public static class PathDrawerUtils
{
    /// <summary>
    /// Redraw all edges on a graph and color a path
    /// </summary>
    /// <param name="graph"></param>
    /// <param name="path"></param>
    public static void Draw(in Graph graph, in List<Edge> path)
    {
        // Reset previous path
        foreach (var edge in graph.GetEdges())
        {
            if (edge.TryGetComponent(out EdgeVisualization edgeVisualization))
            {
                edgeVisualization.AwayOffPath();
            }            
        }
        
        // Color final path
        foreach (var edge in path)
        {
            if (edge.TryGetComponent(out EdgeVisualization edgeVisualization))
            {
                edgeVisualization.OnPath();
            }  
        }
    }
}
