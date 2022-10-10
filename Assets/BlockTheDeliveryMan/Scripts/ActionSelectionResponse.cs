using UnityEngine;

public class ActionSelectionResponse : MonoBehaviour, ISelectionResponse
{
    private IBuilder _target = null;

    private void Update()
    {
        if (_target == null)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            BuildManager.Instance.BuildItemOn(_target);
        }
    }

    public void OnSelect(Transform selection) => _target = selection.GetComponent<IBuilder>();
    public void OnDeselect(Transform selection) => _target = null;
}
