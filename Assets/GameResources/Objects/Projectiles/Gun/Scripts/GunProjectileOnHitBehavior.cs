using UnityEngine;

/// <summary>
/// Gun projectile on hit behaviour
/// </summary>
public class GunProjectileOnHitBehavior : MonoBehaviour
{
    [SerializeField] private GunProjectile projectile = default;    

    private void OnHit(Collider collider)
    {
        if (collider.TryGetComponent(out AbstractTeamMark team))
        {
            if (team.GetType() == typeof(BadTeam))
            {
                projectile.IsActive = false;

                if (collider.TryGetComponent(out DamageTakingController damageTakingController))
                {
                    damageTakingController.TakeDamage(projectile.ProjectileData.Damage);
                }
            }

            return;
        }

        projectile.IsActive = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        OnHit(collider);
    }
}
