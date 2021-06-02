using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 0.2f;

    private float horizontal;
    private float vertical;

    private PlayerActions inputActions;

    private void OnEnable()
    {
        inputActions = new PlayerActions();

        inputActions.Main.Enable();
        inputActions.Main.Movement.performed += OnMovement;
        inputActions.Main.Movement.canceled += OnMovement;
    }

    private void OnDisable()
    {
        inputActions.Main.Disable();
        inputActions.Main.Movement.performed -= OnMovement;
        inputActions.Main.Movement.canceled -= OnMovement;
    }

    private void FixedUpdate()
    {
        float x = MoveSpeed * horizontal;
        float z = MoveSpeed * vertical;

        transform.position += z * transform.forward;
        transform.position += x * transform.right;
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        horizontal = input.x;
        vertical = input.y;
    }
}
