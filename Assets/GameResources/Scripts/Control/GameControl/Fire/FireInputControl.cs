using System;
using UnityEngine.InputSystem;

/// <summary>
/// Player movement input
/// </summary>
public class FireInputControl : AbstractInputControl
{
    public event Action Input;

    protected override void SubscribeInputActions()
    {
        inputActions.Main.Fire.performed += OnInput;
    }

    protected override void UnsubscribeInputActions()
    {
        inputActions.Main.Fire.performed -= OnInput;
    }

    private void OnInput(InputAction.CallbackContext context)
    {
        Input?.Invoke();
    }
}
