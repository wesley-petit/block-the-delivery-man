using System;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] private Transform _endIndicator;
    
    private GameState _gameState;
    private PathController _pathController;
    
    private void Awake()
    {
        _gameState = FindObjectOfType<GameState>();
        _pathController = FindObjectOfType<PathController>();
    }

    private void OnMouseDown()
    {
        Node node = GetComponent<Node>();
        _gameState.EndNode = node;
        _endIndicator.position = node.BuildPosition;
        
        _pathController.ComputeShortestPath();
    }
}
