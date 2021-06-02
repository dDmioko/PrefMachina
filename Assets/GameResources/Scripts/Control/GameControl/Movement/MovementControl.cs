using UnityEngine;

/// <summary>
/// Movement control
/// </summary>
[RequireComponent(typeof(MovementInput))]
public class MovementControl : MonoBehaviour
{
    [SerializeField] private MovementInput input = default;

    [SerializeField] private float speed = 0.2f;

    private Vector2 direction = Vector2.zero;

    private void OnEnable()
    {
        input.Movement += OnMovement;
    }

    private void OnDisable()
    {
        input.Movement -= OnMovement;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float x = speed * direction.x;
        float z = speed * direction.y;

        transform.position += z * transform.forward + x * transform.right;
    }

    private void OnMovement(Vector2 direction)
    {
        this.direction = direction;
    }
}
