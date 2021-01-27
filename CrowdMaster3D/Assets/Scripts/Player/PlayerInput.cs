using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private Vector3 tapPosition;

    public event UnityAction<Vector2> DirectionChanged;

    public delegate void Pointer();
    public event Pointer PointerUp;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tapPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            DirectionChanged?.Invoke(Input.mousePosition - tapPosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            PointerUp?.Invoke();
        }
    }
}
