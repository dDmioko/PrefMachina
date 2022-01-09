using ModuleBallistics;
using UnityEngine;

public class DefaultGun : AbstractGunWithTeam
{
    [SerializeField]
    private Caster caster = default;

    [SerializeField]
    private AbstractProjectileData projectileData = default;

    [SerializeField]
    private float cooldown = 0.5f;

    private bool isFireing = false;
    private float lastShootTime = 0;

    public override void StartFire()
    {
        isFireing = true;
    }

    public override void StopFire()
    {
        isFireing = false;
    }

    private void FixedUpdate()
    {
        if (isFireing == false)
        {
            return;
        }

        if (Time.time >= lastShootTime + cooldown)
        {
            shootData.position = transform.position;
            shootData.rotation = transform.rotation;

            caster.Cast(shootData, projectileData);
            lastShootTime = Time.time;
        }
    }
}
