using System;
using UnityEngine;

// Character Movement for Delivery Guy and other NPC
public class CharacterMovement : MonoBehaviour
{
	[SerializeField] private float _movementTime = 5f;
	[SerializeField] private float _validReachDistance = 0.01f;

	private Transform _thisTransform = null;

	private void Awake() => _thisTransform = transform;

	public void Teleport(Vector3 targetPosition) => _thisTransform.position = targetPosition;

	public void Move(Vector3 targetPosition) => _thisTransform.position = Vector3.Lerp(_thisTransform.position, targetPosition, _movementTime * Time.deltaTime);

	public bool IsReachingTarget(Vector3 targetPosition) => Vector3.Distance(_thisTransform.position, targetPosition) <= _validReachDistance;
}
