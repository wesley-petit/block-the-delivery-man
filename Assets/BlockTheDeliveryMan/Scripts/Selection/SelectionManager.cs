using UnityEngine;

/// <summary>
/// Manage selection and deselection of items
/// </summary>
public class SelectionManager : MonoBehaviour
{
    /// <summary>
    /// Controls selection process
    /// </summary>
    private ISelector _selector;
    
    /// <summary>
    /// Response to a new or old selection
    /// </summary>
    private ISelectionResponse[] _selectionResponse;

    private Transform _currentSelection;
    
    private void Awake()
    {
        _selector = GetComponent<ISelector>();
        _selectionResponse = GetComponents<ISelectionResponse>();
    }

    private void Update()
    {
        // Detect current Selection
        _selector.Check();
        var selection = _selector.GetSelection();

        if (_currentSelection != selection)
        {
            ChangeSelection(selection);
        }
    }

    /// <summary>
    /// Change focus on the last item that has been found
    /// </summary>
    /// <param name="selection"></param>
    private void ChangeSelection(Transform selection)
    {
        // Deselect current item
        if (_currentSelection)
        {
            foreach (var current in _selectionResponse)
            {
                current.OnDeselect(_currentSelection);
            }
        }
        
        // Select new item
        _currentSelection = selection;
        if (_currentSelection)
        {
            foreach (var current in _selectionResponse)
            {
                current.OnSelect(_currentSelection);
            }
        } 
    }
}
