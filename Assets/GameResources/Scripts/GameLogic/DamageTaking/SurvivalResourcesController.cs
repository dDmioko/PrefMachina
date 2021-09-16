using UnityEngine;

/// <summary>
/// Control components that take damage
/// </summary>
public class SurvivalResourcesController : MonoBehaviour
{
    [SerializeField] private Health health = default;
    [SerializeField] private Shield shield = null;

    /// <summary>
    /// Shield and health take damage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(Damage damage)
    {
        Damage currentDamage = damage;

        if (shield)
        {
            currentDamage = shield.TakeDamage(currentDamage);                       
        }

        health.TakeDamage(currentDamage);
    }
}
