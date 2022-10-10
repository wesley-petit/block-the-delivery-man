using System.Collections;
using UnityEngine;

public interface IBuildResponse
{
    void OnBuild();
    void OnUnbuild();
}

public class Node : MonoBehaviour, IBuilder
{
    [SerializeField] private VoidGameEvent OnBuild;

    [SerializeField] private EdgeGameEvent onSwitchDelivery;
    [SerializeField] private Vector3 _buildOffset = new Vector3(0f, 0.5f, 0f);

    private GameObject _buildItem;

    public bool IsOccupied() => _buildItem != null;

    public Vector3 GetBuildPosition() => transform.position + _buildOffset;

    public void Build(GameObject item, bool moveDelivery)
    {
        // IBuildResponse buildResponse = _buildItem.GetComponent<IBuildResponse>();
        // buildResponse.OnUnbuild();
        _buildItem = item;

        if (moveDelivery)
        {
            onSwitchDelivery.Raise(GetComponent<Vertex>());
        }
        else
        {
            GetComponent<Vertex>().IsReachable = false;
            Debug.Log(GetComponent<Vertex>().IsReachable);
            OnBuild.Raise(new Void());
            StartCoroutine(UnBuild_Coroutine());
        }
    }

    public void UnBuild()
    {
        // IBuildResponse buildResponse = _buildItem.GetComponent<IBuildResponse>();
        // buildResponse.OnUnbuild();
        GetComponent<Vertex>().IsReachable = true;
        Destroy(_buildItem);
        _buildItem = null;
        OnBuild.Raise(new Void());
    }

    private IEnumerator UnBuild_Coroutine()
    {
        yield return new WaitForSeconds(6.0f);
        UnBuild();
    }
}
