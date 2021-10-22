using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Do explosion and destroy self
/// </summary>
public class ExplodeSelf : MonoBehaviour
{    
    public UnityEvent Explosion;

    [SerializeField]
    private Collider ownCollider = default;

    [SerializeField]
    private float explosionRadius = 2.5f;

    [SerializeField]
    private Damage damage = default;

    [SerializeField]
    private float force = 10f;

    private Coroutine coroutine = null;

	private void OnDisable()
	{
		if (coroutine != null)
		{
            StopCoroutine(coroutine);
		}
	}

	public void Explode(float delay = 0)
	{
        coroutine = StartCoroutine(WaitForExplosion(delay));
	}

    private IEnumerator WaitForExplosion(float delay)
	{
        yield return new WaitForSeconds(delay);

        Explosion?.Invoke();
        Explode();
    }

    private void Explode()
	{        
        Collider[] hittedColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hittedCollider in hittedColliders)
		{
            if (ownCollider == hittedCollider)
			{
                continue;
			}

            if (hittedCollider.TryGetComponent(out SurvivalResourcesController controller))
            {
                controller.TakeDamage(damage);
            }

            if (hittedCollider.attachedRigidbody)
			{
                hittedCollider.attachedRigidbody.AddExplosionForce(force, transform.position, explosionRadius);
            }
		}
	}
}
