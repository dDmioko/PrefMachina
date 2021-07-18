using ModuleBallistics;
using UnityEngine;

public class Gun : AbstractGun
{
    [SerializeField] private Caster caster = default;

    [SerializeField] private AbstractProjectileData projectileData = default;

    private ShootData shootData = new ShootData();

    public override void Fire()
    {
        shootData.position = transform.position;
        shootData.rotation = transform.rotation;

        caster.Cast(shootData, projectileData);
    }
}
