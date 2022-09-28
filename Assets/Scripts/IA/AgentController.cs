using System;
using UnityEngine;
using System.Collections.Generic;

public class AgentController : MonoBehaviour
{
	[SerializeField] private PathController _pathController;
	[SerializeField] private CharacterMovement _characterMovement;

	private Node _currentTarget;

	private void Start()
	{
		_currentTarget = _pathController.GetStartNode();
		_characterMovement.Teleport(_currentTarget.Position);
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
			_currentTarget = _pathController.GetNextTarget(_currentTarget);
		}
	}
	
	private void SetNextTarget()
	{
		// if (_currentTarget && _currentTarget.Occupied)
		// {
		// 	InteractWithItem();
		// }
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
