using UnityEngine;

public class AgentController : MonoBehaviour
{
	[SerializeField] private CharacterMovement _characterMovement;

	private PathController _pathController;
	private Vector3 _nextPosition;

	private void Awake()
	{
		_pathController = FindObjectOfType<PathController>();
	}

	public void Start()
	{
		_nextPosition = _pathController.GetNextTarget();
		_characterMovement.Teleport(_nextPosition);
	}

	private void Update()
	{
		_characterMovement.Move(_nextPosition);

		if (_characterMovement.IsReachingTarget(_nextPosition))
		{
			if (_pathController.HasAValidPath())
			{
				_nextPosition = _pathController.GetNextTarget();
			}
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

