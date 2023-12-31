using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInput;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayActions
{
    private PlayerInput input;

    public event Action F_Event;
    public event Action LClick_Event;

    public Vector2 MoveInputValue { get; private set; }
    public Vector2 MouseDeltaValue { get; private set; }

    private void OnEnable()
    {
        if(input == null)
        {
            input = new PlayerInput();
            input.Play.SetCallbacks(this);
        }

        input.Play.Enable();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
            F_Event?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInputValue = context.ReadValue<Vector2>();
    }

    public void OnMouseMove(InputAction.CallbackContext context)
    {
        MouseDeltaValue = context.ReadValue<Vector2>();
    }

    public void OnLClick(InputAction.CallbackContext context)
    {
        if(context.performed)
            LClick_Event?.Invoke();
    }
}
