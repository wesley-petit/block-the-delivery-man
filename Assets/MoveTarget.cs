using System;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private Transform _endIndicator;

    private void Awake() => _gameState = FindObjectOfType<GameState>();

    private void OnMouseDown()
    {
        Node node = GetComponent<Node>();
        _gameState.EndNode = node;
        _endIndicator.position = node.BuildPosition;
    }
}
