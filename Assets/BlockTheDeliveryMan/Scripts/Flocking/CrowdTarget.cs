using UnityEngine;

public class CrowdTarget : MonoBehaviour
{
    private Camera _camera;
    private Transform _thisTransform;

    private void Awake()
    {
        _camera = Camera.main;
        _thisTransform = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo))
            {
                _thisTransform.position = new Vector3(hitInfo.point.x, 0f, hitInfo.point.z);
            }
        }
    }
}
