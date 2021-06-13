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

    private float startForce;

    private Vector3 previousPosition;

    public override void Init(Vector3 position, Quaternion direction, AbstractProjectileData data)
    {
        GunProjectileData downCastedData = data as GunProjectileData;

        base.Init(position, direction, data);

        startForce = downCastedData.StartForce;

        previousPosition = transform.position;

        IsActive = true;

        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.AddForce(transform.forward * startForce, ForceMode.Impulse);
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
        transform.rotation = direction != Vector3.zero ? Quaternion.LookRotation(direction) : transform.rotation;

        previousPosition = transform.position;
    }

    protected void CheckOffScreenPosition()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPoint.x < -outOfScreenDistance)
        {
            IsActive = false;

            return;
        }

        if (screenPoint.x > Screen.width + outOfScreenDistance)
        {
            IsActive = false;

            return;
        }

        if (screenPoint.y < -outOfScreenDistance)
        {
            IsActive = false;

            return;
        }

        if (screenPoint.y > Screen.height + outOfScreenDistance)
        {
            IsActive = false;

            return;
        }
    }
}
