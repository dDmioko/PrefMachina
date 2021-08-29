using UnityEngine;

public class DamageTakingController : MonoBehaviour
{
    [SerializeField] private DamageTaker[] damageTakers;

    public void TakeDamage(Damage damage)
    {
        Damage restDamage = damage;

        foreach (DamageTaker damageTaker in damageTakers)
        {
            restDamage = damageTaker.TakeDamage(restDamage);
        }
    }
}
