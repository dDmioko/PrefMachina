using ModuleBallistics;
using UnityEngine;

/// <summary>
/// Simple rigidbody based ballistic projectile
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class GunProjectile : AbstractProjectile
{
    [SerializeField] private Rigidbody body = default;

    private AbstractTeamMark team = default;
    public AbstractTeamMark Team { get => team; }

    private int damage = 0;
    public int Damage => damage;

    public override void Init(ShootData shootData, AbstractProjectileData projectileData)
    {
        ShootMarkData downCastedShootData = shootData as ShootMarkData;
        GunProjectileData downCastedProjectileData = projectileData as GunProjectileData;

        base.Init(shootData, projectileData);

        IsActive = true;

        team = downCastedShootData.team;

        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.AddForce(transform.forward * downCastedProjectileData.StartForce, ForceMode.Impulse);
    }
}
