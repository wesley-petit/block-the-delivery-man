/// <summary>
/// Change a item or selection on select event
/// </summary>
public interface ISelectionResponse
{
    public void OnSelect(UnityEngine.Transform selection);
    public void OnDeselect(UnityEngine.Transform selection);
}