using UnityEngine;

public enum ButtonState
{
	NO_PRESS,
	UP,
	HOLD,
	DOWN
}

public class InputController : MonoBehaviour
{
	[SerializeField] private float _deadZone = 0.01f;

	public Vector2 AxisRaw => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	public Vector2 MousePosition => Input.mousePosition;
	public bool SpeedModifier => Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
	public float Rotate
	{
		get
		{
			if (Input.GetKey(KeyCode.A)) return 1;
			if (Input.GetKey(KeyCode.E)) return -1;
			return 0;
		}
	}
	public float Zoom
	{
		get
		{
			if (Input.GetKey(KeyCode.R)) return 1;
			if (Input.GetKey(KeyCode.F)) return -1;
			return 0;
		}
	}
	public Vector2 MouseScroll => Input.mouseScrollDelta;
	public ButtonState LeftClickState
	{
		get
		{
			if (Input.GetMouseButtonDown(0))
			{
				return ButtonState.DOWN;
			}
			else if (Input.GetMouseButton(0))
			{
				return ButtonState.HOLD;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				return ButtonState.UP;
			}

			return ButtonState.NO_PRESS;
		}
	}
	public ButtonState RightClickState
	{
		get
		{
			if (Input.GetMouseButtonDown(1))
			{
				return ButtonState.DOWN;
			}
			else if (Input.GetMouseButton(1))
			{
				return ButtonState.HOLD;
			}
			else if (Input.GetMouseButtonUp(1))
			{
				return ButtonState.UP;
			}

			return ButtonState.NO_PRESS;
		}
	}
	public bool DeadZoneAxisRaw => AxisRaw.magnitude <= _deadZone;
	public bool DeadZoneMouseScroll => MouseScroll.magnitude <= _deadZone;
	public bool DeadZoneRotate => Mathf.Abs(Rotate) <= _deadZone;
	public bool DeadZoneZoom => Mathf.Abs(Zoom) <= _deadZone;
}