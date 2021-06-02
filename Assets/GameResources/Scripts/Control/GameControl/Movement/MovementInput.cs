using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player movement input
/// </summary>
public class MovementInput : AbstractInputControl
{
    public event Action<Vector2> Movement = delegate { };

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
        Movement(context.ReadValue<Vector2>());
    }
}
