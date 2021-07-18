using ModuleBallistics;
using UnityEngine;

/// <summary>
/// Gun with team mark
/// </summary>
public class Gun : AutoGun
{
    [SerializeField] private AbstractTeamMark team = default;

    protected new ShootMarkData shootData = new ShootMarkData();

    protected void Awake()
    {
        shootData.team = team;
    }

    protected override void Fire()
    {
        shootData.position = transform.position;
        shootData.rotation = transform.rotation;

        caster.Cast(shootData, projectileData);
        lastShootTime = Time.time;
    }
}
