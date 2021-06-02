using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player movement
/// </summary>
public class Movement : AbstractInputControl
{
    [SerializeField] private float speed = 0.2f;

    private float horizontal = 0;
    private float vertical = 0;    

    private void FixedUpdate()
    {
        Move();        
    }

    private void Move()
    {
        float x = speed * horizontal;
        float z = speed * vertical;

        transform.position += z * transform.forward + x * transform.right;
    }

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
        Vector2 input = context.ReadValue<Vector2>();

        horizontal = input.x;
        vertical = input.y;
    }
}
