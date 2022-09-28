using UnityEngine;
using System.Collections.Generic;

public class AgentController : MonoBehaviour
{
	[SerializeField] private Node _startNode = null;
	[SerializeField] private Node _endNode = null;
	[SerializeField] private Dijkstra _pathfinding;
	[SerializeField] private CharacterMovement _characterMovement;
	
	private Node _currentTarget;
	
	private void Start()
	{
		_characterMovement.Teleport(_startNode.BuildPosition);
		_currentTarget = _startNode;
	}

	private void Update()
	{
		if (!_currentTarget)
		{
			enabled = false;
			return;
		}

		_characterMovement.Move(_currentTarget.BuildPosition);

		if (_characterMovement.IsReachingTarget(_currentTarget.BuildPosition))
		{
			SetNextTarget();
		}
	}
	
	private void SetNextTarget()
	{
		Stack<Node> path = _pathfinding.GetShortestPath(_currentTarget, _endNode);
		_currentTarget = null;
		if (path != null && 0 < path.Count)
		{
			_currentTarget = path.Pop();
		}

		if (_currentTarget && _currentTarget.Occupied)
		{
			InteractWithItem();
		}
	}

	private void InteractWithItem()
	{
		// IInteractItem interactItem = _currentTarget.Occupied.GetComponent<IInteractItem>();
		// if (interactItem != null)
		// {
		// 	interactItem.Interact(this);
		// }
	}

	//TODO Implemente la fuite
	public void Flee()
	{
		// _pathfinding.CreatePath(_previousTarget, _endNode, _currentTarget);
		// _currentTarget = _pathfinding.GetTargetNode;
		// _nextTarget = _pathfinding.GetTargetNode;
	}
	
	//TODO Implemente l'évitement des obstacles
	public void Avoid()
	{
		// _pathfinding.CreatePath(_currentTarget, _endNode, _currentTarget);
		// _currentTarget = _pathfinding.GetTargetNode;
		// _nextTarget = _pathfinding.GetTargetNode;
	}
}
