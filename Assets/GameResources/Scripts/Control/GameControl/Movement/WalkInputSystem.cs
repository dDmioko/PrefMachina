using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player walk input
/// </summary>
public class WalkInputSystem : AbstractInputControl
{    
    protected override void OnUpdate() { }

    protected override void SubscribeInputActions()
    {
        inputActions.Main.Movement.performed += OnInput;
        inputActions.Main.Movement.canceled += OnInput;
    }

    protected override void UnsubscribeInputActions()
    {
        inputActions.Main.Movement.performed -= OnInput;
        inputActions.Main.Movement.canceled -= OnInput;
    }

    private void OnInput(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        Entities.ForEach((ref Walk walk, in WalkInput input, in Translation translation) => {

            float x = walk.speed * direction.x;
            float z = walk.speed * direction.y;

            walk.velocity = z * Vector3.forward + x * Vector3.right;

        }).Run();        
    }
}
