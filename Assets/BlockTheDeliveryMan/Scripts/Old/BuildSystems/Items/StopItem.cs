using UnityEngine;

public class StopItem : MonoBehaviour, IBuilder, IInteractItem
{
	[SerializeField] private float _maxLifetime = 4f;

	private float _lifetime = 0f;
	// private Node _node = null;
	private AgentController _agent = null;

	// private void Update()
	// {
	// 	_lifetime += Time.deltaTime;
	// 	if (_maxLifetime < _lifetime)
	// 	{
	// 		UnBuild();	
	// 	}
	// }
	//
	// // public void Build(Node node) => _node = node;
	//
	// public void UnBuild()
	// {
	// 	Destroy(gameObject);
	//
	// 	if (_node)
	// 	{
	// 		_node.Occupied = null;
	// 	}
	//
	// 	if (_agent)
	// 	{
	// 		_agent.enabled = true;
	// 	}
	// }
	//
	// public void Interact(AgentController agent)
	// {
	// 	_agent = agent;
	// 	_agent.enabled = false;
	// }
}
