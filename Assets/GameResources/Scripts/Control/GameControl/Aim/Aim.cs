using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player direction
/// </summary>
[RequireComponent(typeof(AimDeadZone))]
public class Aim : AbstractInputControl
{
    private const string MOUSE_DEVICE = "Mouse";
    private readonly Vector3 SCREEN_CENTER = new Vector3(Screen.width, 0, Screen.height) / 2;    

    [Range(0, Mathf.PI)]
    [SerializeField] private float speed = Mathf.PI;

    [SerializeField] private AimDeadZone deadZone;

    private Vector3 normalizedDirection = Vector2.zero;           

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector3 newDir = Vector3.RotateTowards(transform.forward, normalizedDirection, speed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

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
            SetMouseNormalizedDirection(input);

            return;
        }

        SetNormalizedDirection(input);
    }
    
    private void SetMouseNormalizedDirection(Vector2 input)
    {        
        Vector3 aim = new Vector3(input.x / SCREEN_CENTER.x, 1, input.y / SCREEN_CENTER.z) - Vector3.one;

        if (deadZone.Check(aim, true) == false)
        {
            normalizedDirection = aim.normalized;

            return;
        }
    }

    private void SetNormalizedDirection(Vector2 input)
    {
        Vector3 aim = new Vector3(input.x, 0, input.y);

        if (deadZone.Check(aim, false) == false)
        {
            normalizedDirection = aim.normalized;

            return;
        }
    }    
}
