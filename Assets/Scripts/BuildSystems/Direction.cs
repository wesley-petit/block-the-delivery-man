using UnityEngine;

public enum Direction
{
	UP, DOWN, LEFT, RIGHT
}

public struct VectorDirection
{
	public VectorDirection(Direction direction, Vector3 position)
	{
		Direction = direction;
		Position = position;
	}

	public Direction Direction { get; private set; }
	public Vector3 Position { get; private set; }
}

public static class DirectionToVector
{
	public static Vector3 UP => new Vector3(0f, 0f, 1f);
	public static Vector3 RIGHT => new Vector3(1f, 0f);
	public static Vector3 DOWN => new Vector3(0f, 0f, -1f);
	public static Vector3 LEFT => new Vector3(-1f, 0f);

	public static VectorDirection[] ALL_DIRECTIONS => _directionsToVector;
	public static int MAX_DIRECTION => ALL_DIRECTIONS.Length;

	private static VectorDirection[] _directionsToVector =
	{
		new VectorDirection(Direction.UP, UP),
		new VectorDirection(Direction.RIGHT, RIGHT),
		new VectorDirection(Direction.DOWN, DOWN),
		new VectorDirection(Direction.LEFT, LEFT)
	};
}