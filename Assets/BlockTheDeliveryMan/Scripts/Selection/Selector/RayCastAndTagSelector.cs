using UnityEngine;
using WSWhitehouse.TagSelector;

/// <summary>
/// Select item with an raycast, then check if it has the correct tag
/// </summary>
public class RayCastAndTagSelector : MonoBehaviour, ISelector
{
    /// <summary>
    /// Camera to create a raycast with mouse position
    /// </summary>
    [SerializeField] private Camera _camera;
    
    /// <summary>
    /// Tag to filter selections
    /// </summary>
    [SerializeField, TagSelector] private string _selectableTag = "Selectable";

    private Transform _selection;

    /// <summary>
    /// Update selection with last mouse position
    /// </summary>
    public void Check()
    {
        _selection = null;

        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        { 
            if (hit.transform.CompareTag(_selectableTag))
            {
                _selection = hit.transform;
            }
        }
    }

    /// <summary>
    /// If any, return the current selection
    /// </summary>
    /// <returns></returns>
    public Transform GetSelection() => _selection;
}
