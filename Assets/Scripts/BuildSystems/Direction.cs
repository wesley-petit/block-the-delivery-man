using UnityEngine;

// Search direction for neighbors
public static class DirectionLibrary
{
	public static readonly Vector3[] ALL_DIRECTIONS =
	{
		UP,
		RIGHT,
		DOWN,
		LEFT
	};
	
	private static Vector3 UP => new (0f, 0f, 1f);
	private static Vector3 RIGHT => new (1f, 0f);
	private static Vector3 DOWN => new (0f, 0f, -1f);
	private static Vector3 LEFT => new (-1f, 0f);
}