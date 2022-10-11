using System;
using UnityEngine;

public class InputRaycast : MonoBehaviour
{
    public event Action<Vector2, RaycastHit2D> Hiting2D;
    public event Action<Vector2> Missing2D;
    public event Action ButtonMouseUp;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        InputMouse();
    }

    private void InputMouse()
    {
        if (Input.GetMouseButton(0))
        {
            Hit2DRay(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            ButtonMouseUp?.Invoke();
        }
    }

    private void Hit2DRay(Vector3 screenPosition)
    {
        Vector2 position = (Vector2)_camera.ScreenToWorldPoint(screenPosition);
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);

        if (hit.collider)
        {
            Hiting2D?.Invoke(position, hit);
        }
        else
        {
            Missing2D?.Invoke(position);
        }
    }
}
