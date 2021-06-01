using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    [Range(0, Mathf.PI)]
    [SerializeField] private float RotSpeed = Mathf.PI;
    [SerializeField] private float MinDeadZone = 0.125f;
    //[SerializeField] private float MaxDeadZone = 0.925f;

    private Vector3 normalizedDirection;
    private bool isMouse = false;
    private PlayerActions inputActions;

    private readonly Vector3 centre = new Vector3(Screen.width, 0, Screen.height) / 2;

    private void OnEnable()
    {
        inputActions = new PlayerActions();

        inputActions.Main.Enable();
        inputActions.Main.Aim.performed += OnMovement;
        inputActions.Main.Aim.canceled += OnMovement;
    }

    private void OnDisable()
    {
        inputActions.Main.Disable();
        inputActions.Main.Aim.performed -= OnMovement;
        inputActions.Main.Aim.canceled -= OnMovement;
    }

    private void FixedUpdate()
    {
        
        Vector3 newDir = Vector3.RotateTowards(transform.forward, normalizedDirection, RotSpeed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        Vector3 aim = new Vector3(input.x, 0, input.y);

        isMouse = context.control.device.displayName.Equals("Mouse");
        Vector3 aimMouse = new Vector3(aim.x / centre.x, 1, aim.z / centre.z) - Vector3.one;
        normalizedDirection = CheckDeadZone(isMouse ? aimMouse : aim);
    }

    public float inputMagnitude;

    private Vector3 CheckDeadZone(Vector3 input)
    {
        inputMagnitude = input.magnitude;
        if (input.magnitude < MinDeadZone)
        {
            return normalizedDirection;
        }

        return input.normalized;
    }
}
