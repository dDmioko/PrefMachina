using System;
using UnityEngine.InputSystem;

/// <summary>
/// Player movement input
/// </summary>
public class FireInput : AbstractInputControl
{
    public event Action Fire;

    protected override void SubscribeInputActions()
    {
        inputActions.Main.Fire.performed += OnFire;
    }

    protected override void UnsubscribeInputActions()
    {
        inputActions.Main.Fire.performed -= OnFire;
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        Fire?.Invoke();
    }
}
