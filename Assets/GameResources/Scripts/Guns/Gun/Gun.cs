using ModuleBallistics;
using UnityEngine;

public class Gun : AbstractGun
{
    [SerializeField] private Caster caster;

    [SerializeField] private AbstractProjectileData projectileData;

    public override void Fire()
    {
        caster.Cast(transform.position, transform.rotation, projectileData);
    }
}
