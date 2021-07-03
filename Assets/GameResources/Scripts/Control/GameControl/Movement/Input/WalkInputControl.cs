using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player walk input
/// </summary>
public class WalkInputControl : AbstractInputControl
{
    public event Action<Vector2> Movement;

    protected override void SubscribeInputActions()
    {
        inputActions.Main.Movement.performed += OnMovement;
        inputActions.Main.Movement.canceled += OnMovement;
    }

    protected override void UnsubscribeInputActions()
    {
        inputActions.Main.Movement.performed -= OnMovement;
        inputActions.Main.Movement.canceled -= OnMovement;
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        Movement?.Invoke(context.ReadValue<Vector2>());
    }
}
