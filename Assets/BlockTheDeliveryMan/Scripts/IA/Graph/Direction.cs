using UnityEngine;

/// <summary>
/// Direction supported by the program
/// </summary>
public static class DirectionPattern
{
	/// <summary>
	/// Search direction for neighbors. In the future, we could add diagonals.
	/// </summary>
	public static readonly Vector3[] NeighborDirections =
	{
		Vector3.forward,
		Vector3.right,
		Vector3.back,
		Vector3.left
	};
}