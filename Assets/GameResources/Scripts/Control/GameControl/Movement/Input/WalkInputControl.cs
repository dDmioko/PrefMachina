using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player walk input
/// </summary>
public class WalkInputControl : AbstractInputControl
{
    public event Action<Vector2> Input;

    protected override void SubscribeInputActions()
    {
        inputActions.Main.Movement.performed += OnInput;
        inputActions.Main.Movement.canceled += OnInput;
    }

    protected override void UnsubscribeInputActions()
    {
        inputActions.Main.Movement.performed -= OnInput;
        inputActions.Main.Movement.canceled -= OnInput;
    }

    private void OnInput(InputAction.CallbackContext context)
    {
        Input?.Invoke(context.ReadValue<Vector2>());
    }
}
