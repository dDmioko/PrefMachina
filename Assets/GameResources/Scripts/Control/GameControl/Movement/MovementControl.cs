using UnityEngine;

/// <summary>
/// Movement control
/// </summary>
[RequireComponent(typeof(MovementInput))]
public class MovementControl : MonoBehaviour
{
    [SerializeField] private MovementInput input = default;

    [SerializeField] private Rigidbody body;

    [SerializeField] private float speed = 0.2f;

    private void OnEnable()
    {
        input.Movement += OnMovement;
    }

    private void OnDisable()
    {
        input.Movement -= OnMovement;
    }

    private void OnMovement(Vector2 direction)
    {
        float x = speed * direction.x;
        float z = speed * direction.y;

        body.velocity = z * transform.forward + x * transform.right;
    }
}
