using ModuleBallistics;
using UnityEngine;

/// <summary>
/// Simple rigidbody based ballistic projectile
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class GunProjectile : AbstractProjectile
{
    [SerializeField] private Rigidbody body = default;

    public override void Init(ShootData shootData, AbstractProjectileData projectileData)
    {
        GunProjectileData downCastedProjectileData = projectileData as GunProjectileData;

        base.Init(shootData, projectileData);

        IsActive = true;

        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.AddForce(transform.forward * downCastedProjectileData.StartForce, ForceMode.Impulse);
    }
}
