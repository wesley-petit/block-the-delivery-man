using UnityEngine;

public interface IBuilder
{
	public bool IsOccupied();	
	public Vector3 GetBuildPosition();
	
	public void Build(GameObject item, bool moveDelivery);
	public void UnBuild();
}
