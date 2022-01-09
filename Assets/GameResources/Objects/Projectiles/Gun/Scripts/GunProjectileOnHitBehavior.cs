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
			if (team.GetType() != projectile.Team.GetType())
			{
				projectile.IsActive = false;

				if (collider.TryGetComponent(out SurvivalResourcesController damageTakingController))
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
