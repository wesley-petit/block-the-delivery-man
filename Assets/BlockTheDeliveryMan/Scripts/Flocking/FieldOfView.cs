using UnityEditor;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
	[SerializeField, Range(0f, 360f)] private float _viewAngle = 70f;
	[SerializeField, Range(0f, 10.0f)] private float _viewRadius = 2.0f;
	[SerializeField] private Color _debugColor;

	private float ViewAngleBySide => _viewAngle / 2.0f;
	
	public bool IsVisible(in Boid origin, in Boid target)
	{
		Vector3 directionToTarget = target.GetPosition - origin.GetPosition;
		directionToTarget.Normalize();

		return Vector3.Distance(origin.GetPosition, target.GetPosition) < _viewRadius && IsInView(origin.transform.forward, directionToTarget);
	}

	private bool IsInView(Vector3 forwardVector, Vector3 directionToTarget)
	{
		return Vector3.Angle(forwardVector, directionToTarget) <= ViewAngleBySide;
	}

	private void OnDrawGizmosSelected()
	{
#if  UNITY_EDITOR
		var currentTransform = transform;
		var position = currentTransform.position;
		var leftLimit = Helpers.DirFromAngle(-ViewAngleBySide, currentTransform) * _viewRadius;
		var rightLimit = Helpers.DirFromAngle(ViewAngleBySide, currentTransform) * _viewRadius;

		Handles.color = _debugColor;
		Handles.DrawLine(position, position + leftLimit);
		Handles.DrawLine(position, position + rightLimit);
		Handles.DrawWireArc(position, Vector3.up, leftLimit, _viewAngle, _viewRadius);
#endif
	}
}