using UnityEngine;

public class FleeItem : MonoBehaviour, IInteractItem
{
	public void Interact(AgentController agent) => agent.Flee();
}
