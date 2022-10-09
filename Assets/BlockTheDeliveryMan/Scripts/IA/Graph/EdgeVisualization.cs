using UnityEngine;

/// <summary>
/// Give some visualization when a edge is on the agent path or not
/// </summary>
public class EdgeVisualization : MonoBehaviour
{
    [SerializeField] private GameObject edgeGfx;

    private void Start() => AwayOffPath();

    public void OnPath() => edgeGfx.SetActive(true);
    public void AwayOffPath() => edgeGfx.SetActive(false);
}
