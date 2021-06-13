using ModuleBallistics;
using UnityEngine;

/// <summary>
/// Simple rigidbody based ballistic projectile
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class GunProjectile : AbstractProjectile
{
    [SerializeField] private Rigidbody body;

    [Tooltip("In pixels. If projectile fly further - it deactivates")]
    [SerializeField] private float outOfScreenDistance = 50f;

    private Rect screenBox;

    private Vector3 previousPosition;

    private void Awake()
    {
        screenBox = new Rect(-outOfScreenDistance,
            -outOfScreenDistance,
            Screen.width + outOfScreenDistance,
            Screen.height + outOfScreenDistance);
    }

    public override void Init(Vector3 position, Quaternion direction, AbstractProjectileData data)
    {
        GunProjectileData downCastedData = data as GunProjectileData;

        base.Init(position, direction, data);

        previousPosition = transform.position;

        IsActive = true;

        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.AddForce(transform.forward * downCastedData.StartForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        if (IsActive)
        {
            Move();

            CheckOffScreenPosition();
        }
    }

    protected override void Move()
    {
        Vector3 direction = transform.position - previousPosition;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        previousPosition = transform.position;
    }

    protected void CheckOffScreenPosition()
    {
        Vector3 vec3 = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 projectileOnRect = new Vector2(vec3.x, vec3.z);

        if (screenBox.Contains(projectileOnRect, true) == false)
        {
            IsActive = false;
        }
    }
}
