using UnityEngine;
using Leopotam.Ecs;

/// <summary>
/// Gun projectile on hit behaviour
/// </summary>
public class GunProjectileOnHitBehavior : MonoBehaviour
{
    [SerializeField] private GunProjectile projectile = default;

    private void OnHit(Collider collider)
    {
        if (collider.TryGetComponent(out AbstractTeamMark team) == false)
        {
            projectile.IsActive = false;

            if (collider.TryGetComponent(out EntityProvider entity))
            {
                entity.Entity.Replace(new Damage() { Amount = projectile.Damage } );
            }

            return;
        }

        if (projectile.Team.GetType() != team.GetType())
        {
            projectile.IsActive = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        OnHit(collider);
    }
}
