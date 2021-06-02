using UnityEngine;

/// <summary>
/// Aim control
/// </summary>
[RequireComponent(typeof(AimInput))]
public class AimControl : MonoBehaviour
{
    [SerializeField] private AimInput input = default;

    [Range(0, Mathf.PI)]
    [SerializeField] private float speed = Mathf.PI;

    private Vector3 direction = Vector2.zero;

    private void OnEnable()
    {
        input.Aim += OnAim;
    }

    private void OnDisable()
    {
        input.Aim -= OnAim;
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector3 newDir = Vector3.RotateTowards(transform.forward, new Vector3(direction.x, 0, direction.y), speed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void OnAim(Vector2 direction)
    {
        this.direction = direction;
    }
}
