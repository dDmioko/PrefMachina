using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player aim input
/// </summary>
[RequireComponent(typeof(AimDeadZone))]
public class AimInput : AbstractInputControl
{
    private const string MOUSE_DEVICE = "Mouse";

    private readonly Vector2 SCREEN_CENTER = new Vector2(Screen.width, Screen.height) / 2;

    public event Action<Vector2> Aim = delegate { };

    [SerializeField] private AimDeadZone deadZone;

    protected override void SubscribeInputActions()
    {
        inputActions.Main.Aim.performed += OnAim;
        inputActions.Main.Aim.canceled += OnAim;        
    }

    protected override void UnsubscribeInputActions()
    {
        inputActions.Main.Aim.performed -= OnAim;
        inputActions.Main.Aim.canceled -= OnAim;
    }

    private void OnAim(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        bool isMouse = context.control.device.displayName.Equals(MOUSE_DEVICE);        

        if (isMouse)
        {
            SetMouseDirection(input);

            return;
        }

        SetDirection(input);
    }
    
    private void SetMouseDirection(Vector2 input)
    {        
        Vector2 aim = new Vector2(input.x / SCREEN_CENTER.x, input.y / SCREEN_CENTER.y) - Vector2.one;

        if (deadZone.Check(aim, true) == false)
        {            
            Aim(aim.normalized);

            return;
        }
    }

    private void SetDirection(Vector2 input)
    {
        Vector2 aim = new Vector2(input.x, input.y);

        if (deadZone.Check(aim, false) == false)
        {
            Aim(aim.normalized);

            return;
        }
    }    
}
