using UnityEngine;

/// <summary>
/// Highlight object on selection event
/// </summary>
public class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
{
    /// <summary>
    /// Highlight Color
    /// </summary>
    [SerializeField] private Color _color;
    
    /// <summary>
    /// Color of a selection before it was changed to highlight.
    /// </summary>
    private Color _previousColor;
    
    public void OnSelect(Transform selection)
    {
        if (selection.TryGetComponent<Highlightable>(out var highlightable))
        {
            var material = highlightable.Mesh.material;
            _previousColor = material.color;
            material.color = _color;
        }
    }

    public void OnDeselect(Transform selection)
    {
        if (selection.TryGetComponent<Highlightable>(out var highlightable))
        {
            highlightable.Mesh.material.color = _previousColor;
        }
    }
}
