using System;
using UnityEngine.InputSystem;

/// <summary>
/// Player movement input
/// </summary>
public class FireInput : AbstractInputControl
{
    public event Action StartFire;
    public event Action StopFire;

    protected override void SubscribeInputActions()
    {
        inputActions.Main.Fire.performed += OnStartFire;
        inputActions.Main.Fire.canceled += OnStopFire;
    }

    protected override void UnsubscribeInputActions()
    {
        inputActions.Main.Fire.performed -= OnStartFire;
        inputActions.Main.Fire.canceled -= OnStopFire;
    }

    private void OnStartFire(InputAction.CallbackContext context)
    {
        StartFire?.Invoke();
    }

    private void OnStopFire(InputAction.CallbackContext context)
    {
        StopFire?.Invoke();
    }
}
