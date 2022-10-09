using UnityEngine;

/// <summary>
/// Enable outline on object with global properties on selection event
/// </summary>
public class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] private Outline.Mode _mode = Outline.Mode.OutlineAndSilhouette;
    [SerializeField] private Color _color;
    [SerializeField, Range(0f, 10f)] private float _width = 3.0f;

    public void OnSelect(Transform selection)
    {
        if (selection.TryGetComponent<Outline>(out var outline))
        {
            outline.OutlineMode = _mode;
            outline.OutlineColor = _color;
            outline.OutlineWidth = _width;
            outline.enabled = true;
        }
    }

    public void OnDeselect(Transform selection)
    {
        if (selection.TryGetComponent<Outline>(out var outline))
        {
            outline.enabled = false;
        }
    }
}
