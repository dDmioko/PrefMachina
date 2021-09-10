using UnityEngine;

public class SurvivalResourcesController : MonoBehaviour
{
    [SerializeField] private Health health = default;
    [SerializeField] private Shield shield = null;

    public void TakeDamage(Damage damage)
    {
        if (shield)
        {
            Damage restDamage = shield.TakeDamage(damage);
            health.TakeDamage(restDamage);

            return;
        }

        health.TakeDamage(damage);
    }
}
