using UnityEngine;

public class ImportantEdgeIndicator : MonoBehaviour
{
    [SerializeField] private EdgeGameEvent onMove;

    private void OnEnable() => onMove.RegisterListener(Move);
    private void OnDisable() => onMove.UnregisterListener(Move);

    private void Move(Vertex vertex) => transform.position = vertex.GetPosition;
}
