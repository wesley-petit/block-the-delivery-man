using UnityEngine;

[RequireComponent(typeof(InputController))]
public class GodView : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] private float _speed = 1f;
	[SerializeField] private float _movementTime = 5f;
	[SerializeField] private float _fastSpeed = 3f;

	[Header("Rotation")]
	[SerializeField] private float _rotationAmount = 1f;

	[Header("Zoom")]
	[SerializeField] private Vector3 _zoomAmount = new Vector3(0f, -10f, 10f);
	[SerializeField] private Camera _camera = null;
	[SerializeField] private float _minZoom = -50f;
	[SerializeField] private float _maxZoom = 400f;

	private InputController _inputs;
	private Vector3 _newPosition = Vector3.zero;
	private Quaternion _newRotation;
	private Vector3 _newZoom = Vector3.zero;

	private Vector3 _dragStartPosition = Vector3.zero;
	private Vector3 _dragCurrentPosition = Vector3.zero;

	private Vector3 _rotateStartPosition = Vector3.zero;
	private Vector3 _rotateCurrentPosition = Vector3.zero;

	private void Start()
	{
		_inputs = GetComponent<InputController>();
		_newPosition = transform.position;
		_newRotation = transform.rotation;
		// Position relative au camera rig
		_newZoom = _camera.transform.localPosition;
	}

	private void Update()
	{
		// Mouse Input
		DragMove();
		MouseRotate();
		MouseZoom();

		HandleMovementInput();

		ApplyAllValue();
	}

	#region MouseInput
	// Déplace la carte au clic gauche
	private void DragMove()
	{
		if (_inputs.LeftClickState == ButtonState.DOWN)
		{
			_dragStartPosition = HitPlane(_dragStartPosition);
		}

		if (_inputs.LeftClickState == ButtonState.HOLD)
		{
			_dragCurrentPosition = HitPlane(_dragCurrentPosition);
			_newPosition = transform.position + _dragStartPosition - _dragCurrentPosition;
		}
	}

	// Si le Drag du mouse touche le sol
	private Vector3 HitPlane(Vector3 drag)
	{
		Plane plane = new Plane(Vector3.up, Vector3.zero);

		Ray ray = _camera.ScreenPointToRay(_inputs.MousePosition);

		float entry;

		if (plane.Raycast(ray, out entry))
		{
			drag = ray.GetPoint(entry);
		}

		return drag;
	}

	// Rotation avec le clic droit
	private void MouseRotate()
	{
		if (_inputs.RightClickState == ButtonState.DOWN)
		{
			_rotateStartPosition = _inputs.MousePosition;
		}
		if (_inputs.RightClickState == ButtonState.HOLD)
		{
			_rotateCurrentPosition = _inputs.MousePosition;

			Vector3 difference = _rotateStartPosition - _rotateCurrentPosition;

			_rotateStartPosition = _rotateCurrentPosition;
			_newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
		}
	}

	private void MouseZoom()
	{
		if (_inputs.DeadZoneMouseScroll)
		{
			return;
		}

		_newZoom += _inputs.MouseScroll.y * _zoomAmount;
	}
	#endregion

	#region MovementInput
	private void HandleMovementInput()
	{
		// Changement vitesse
		var fastMode = _inputs.SpeedModifier;
		var movementSpeed = fastMode ? _fastSpeed : _speed;

		Move(movementSpeed);
		Rotate();
		Zoom();
	}

	private void Move(float movementSpeed)
	{
		if (_inputs.DeadZoneAxisRaw)
			return;

		var moveAxis = _inputs.AxisRaw;
		// Forward And Backward
		_newPosition += transform.forward * moveAxis.y * movementSpeed;
		// Left And Right
		_newPosition += transform.right * moveAxis.x * movementSpeed;
	}

	private void Rotate()
	{
		if (_inputs.DeadZoneRotate)
			return;

		_newRotation *= Quaternion.Euler(Vector3.up
								   * _rotationAmount
								   * _inputs.Rotate);
	}

	private void Zoom()
	{
		if (_inputs.DeadZoneZoom)
			return;

		_newZoom += _zoomAmount * _inputs.Zoom;
	}
	#endregion

	private void ApplyAllValue()
	{
		transform.position = Vector3.Lerp(transform.position, _newPosition, _movementTime * Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, _movementTime * Time.deltaTime);
		_camera.transform.localPosition = Vector3.Lerp(_camera.transform.localPosition, _newZoom, _movementTime * Time.deltaTime);

		_camera.transform.localPosition = new Vector3(_camera.transform.localPosition.x,
													CameraClamp(_camera.transform.localPosition.y),
													-CameraClamp(-_camera.transform.localPosition.z));
	}

	// Limite la position de la camera
	private float CameraClamp(float value) => Mathf.Clamp(value, _minZoom, _maxZoom);
}