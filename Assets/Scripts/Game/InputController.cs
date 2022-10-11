using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputRaycast _inputRaycast;
    private void Awake()
    {
        _inputRaycast.Hiting2D += test;
    }
    private void test(Vector2 vector2, RaycastHit2D raycastHit)
    {
        if (raycastHit.collider.TryGetComponent(out Square square))
        {
            square.MoveSquare(vector2,StateSquare.Move);
        }
    }
}
