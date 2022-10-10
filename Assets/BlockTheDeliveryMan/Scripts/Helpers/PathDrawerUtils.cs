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
    public static void Draw(in Graph graph, in List<Vertex> path)
    {
        ResetPreviousPath(graph);
        
        // Color final path
        foreach (var v in path)
        {
            if (v.TryGetComponent(out VertexVisualization edgeVisualization))
            {
                edgeVisualization.OnPath();
            }  
        }
    }

    // Reset previous path
    public static void ResetPreviousPath(in Graph graph)
    {
        foreach (var v in graph.GetVertex())
        {
            if (v.TryGetComponent(out VertexVisualization edgeVisualization))
            {
                edgeVisualization.AwayOffPath();
            }            
        }
    }
}
