using System;
using UnityEngine.InputSystem;

/// <summary>
/// Player movement input
/// </summary>
public class FireInputControl : AbstractInputControl
{
    public event Action Up;
    public event Action Down;

    protected override void SubscribeInputActions()
    {
        inputActions.Main.Fire.canceled += OnUp;
        inputActions.Main.Fire.performed += OnDown;
    }

    protected override void UnsubscribeInputActions()
    {
        inputActions.Main.Fire.canceled -= OnUp;
        inputActions.Main.Fire.performed -= OnDown;
    }

    private void OnUp(InputAction.CallbackContext context)
    {
        Up?.Invoke();
    }

    private void OnDown(InputAction.CallbackContext context)
    {
        Down?.Invoke();
    }

    protected override void OnUpdate()
    {
        
    }
}
