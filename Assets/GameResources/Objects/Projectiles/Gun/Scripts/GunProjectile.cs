using ModuleBallistics;
using UnityEngine;

/// <summary>
/// Simple rigidbody based ballistic projectile
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class GunProjectile : AbstractProjectile
{
    [SerializeField] private Rigidbody body;

    public override void Init(Vector3 position, Quaternion direction, AbstractProjectileData data)
    {
        GunProjectileData downCastedProjectileData = projectileData as GunProjectileData;

        base.Init(shootData, projectileData);

        IsActive = true;

        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.AddForce(transform.forward * downCastedProjectileData.StartForce, ForceMode.Impulse);
    }
}
