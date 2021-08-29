using System.Collections;
using UnityEngine;

/// <summary>
/// Shield with regeneration
/// </summary>
public class Shield : DamageTaker
{
    [SerializeField] private bool isRegenerating = true;

    [SerializeField] private float regenerationTime = 0;
    [SerializeField] private int regenerationAmount = 0;

    private Coroutine coroutine = null;

    private float timeToRegeneration;

    private bool isAmountChanged = false;

    private void OnEnable()
    {
        if (isRegenerating)
        {
            coroutine = StartCoroutine(Regenerate());
        }
    }

    private void OnDisable()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    private IEnumerator Regenerate()
    {
        while (true)
        {
            timeToRegeneration = regenerationTime;                    
            
            yield return new WaitUntil(CheckIfCanRegenerate);

            amount += regenerationAmount;

            InvokeAmountChanged(amount, regenerationAmount);
        }
    }

    private bool CheckIfCanRegenerate()
    {
        timeToRegeneration -= Time.deltaTime;

        if (isAmountChanged || amount == maxAmount)
        {
            isAmountChanged = false;

            timeToRegeneration = regenerationTime;

            return false;
        }

        return timeToRegeneration <= 0;
    }

    public override Damage TakeDamage(Damage damage)
    {
        if (damage.amount <= 0)
        {
            return damage;
        }

        if (amount <= 0)
        {
            return damage;
        }

        isAmountChanged = true;

        Damage restDamage = new Damage(damage.amount - amount);

        amount -= damage.amount;
        amount = amount < 0 ? 0 : amount;

        InvokeAmountChanged(amount, -damage.amount);

        return restDamage;
    }
}
