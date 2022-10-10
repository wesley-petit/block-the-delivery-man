using UnityEngine;

/// <summary>
/// Give some visualization when a vertex is on the agent path or not
/// </summary>
public class VertexVisualization : MonoBehaviour
{
    [SerializeField] private GameObject vertexGfx;

    private void Start() => AwayOffPath();

    public void OnPath() => vertexGfx.SetActive(true);
    public void AwayOffPath() => vertexGfx.SetActive(false);
}
