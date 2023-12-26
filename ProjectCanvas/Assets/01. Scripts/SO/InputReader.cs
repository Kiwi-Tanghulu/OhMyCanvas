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

    public event Action<Vector2> Move_Input;
    public event Action F_Input;

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
            F_Input?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();

        Move_Input?.Invoke(inputValue);
    }
}
