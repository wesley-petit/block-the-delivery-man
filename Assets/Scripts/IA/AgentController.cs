using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(Pathfinding))]
public class AgentController : MonoBehaviour
{
	[SerializeField] private Node _startNode = null;
	[SerializeField] private Node _endNode = null;

	private CharacterMovement _characterMovement = null;
	private Pathfinding _pathfinding = null;
	private Node _nextTarget = null;
	private Node _currentTarget = null;
	private Node _previousTarget = null;

	private void Awake()
	{
		_characterMovement = GetComponent<CharacterMovement>();
		_pathfinding = GetComponent<Pathfinding>();
	}

	private void Start()
	{
		_pathfinding.CreatePath(_startNode, _endNode);
		_characterMovement.Teleport(_startNode.BuildPosition);

		_previousTarget = null;
		_currentTarget = _pathfinding.GetTargetNode;
		_nextTarget = _pathfinding.GetTargetNode;
	}

	private void Update()
	{
		if (!_currentTarget)
		{
			enabled = false;
			return;
		}

		_characterMovement.Move(_currentTarget.BuildPosition);

		if (_characterMovement.IsTargetReach(_currentTarget.BuildPosition))
		{
			ChangeTarget();
		}
	}

	private void ChangeTarget()
	{
		_previousTarget = _currentTarget;
		_currentTarget = _nextTarget;
		_nextTarget = _pathfinding.GetTargetNode;

		if (_currentTarget && _currentTarget.Occupied)
		{
			InteractWithItem();
		}
	}

	private void InteractWithItem()
	{
		IInteractItem interactItem = _currentTarget.Occupied.GetComponent<IInteractItem>();
		if (interactItem != null)
		{
			interactItem.Interact(this);
		}
	}

	public void Flee()
	{
		_pathfinding.CreatePath(_previousTarget, _endNode, _currentTarget);
		_currentTarget = _pathfinding.GetTargetNode;
		_nextTarget = _pathfinding.GetTargetNode;
	}

	public void Avoid()
	{
		_pathfinding.CreatePath(_currentTarget, _endNode, _currentTarget);
		_currentTarget = _pathfinding.GetTargetNode;
		_nextTarget = _pathfinding.GetTargetNode;
	}
}
