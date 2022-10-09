/// <summary>
/// Select and filter an item for the selection manager
/// </summary>
public interface ISelector
{
    public void Check();
    public UnityEngine.Transform GetSelection();
}