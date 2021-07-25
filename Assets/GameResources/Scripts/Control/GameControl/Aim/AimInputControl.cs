using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player aim input
/// </summary>
[RequireComponent(typeof(AimDeadZone))]
public class AimInputControl : AbstractInputControl
{
    private const string MOUSE_DEVICE = "Mouse";

    private readonly Vector2 SCREEN_CENTER = new Vector2(Screen.width, Screen.height) / 2;

    public event Action<Vector2> Input;

    [SerializeField] private AimDeadZone deadZone;

    protected override void SubscribeInputActions()
    {
        inputActions.Main.Aim.performed += OnInput;
        inputActions.Main.Aim.canceled += OnInput;
    }

    protected override void UnsubscribeInputActions()
    {
        inputActions.Main.Aim.performed -= OnInput;
        inputActions.Main.Aim.canceled -= OnInput;
    }

    private void OnInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        bool isMouse = context.control.device.displayName.Equals(MOUSE_DEVICE);

        input = isMouse ? GetMouseAim(input) : input;
        SetDirection(input, isMouse);
    }

    private Vector2 GetMouseAim(Vector2 input)
    {
        return new Vector2(input.x / SCREEN_CENTER.x, input.y / SCREEN_CENTER.y) - Vector2.one;
    }

    private void SetDirection(Vector2 input, bool isMouse)
    {
        //if (deadZone.Check(input, isMouse) == false)
        //{
        //    Input?.Invoke(input.normalized);
        //}
    }

    protected override void OnUpdate()
    {
        
    }
}