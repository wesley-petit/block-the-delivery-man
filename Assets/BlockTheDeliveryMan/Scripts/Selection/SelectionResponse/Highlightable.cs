using UnityEngine;

/// <summary>
/// Mesh that can be higlighted on selection event
/// </summary>
public class Highlightable : MonoBehaviour
{
    [field:SerializeField] public MeshRenderer Mesh { get; private set; }
}
