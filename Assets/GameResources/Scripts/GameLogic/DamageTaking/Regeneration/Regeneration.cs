using System.Collections;
using UnityEngine;

/// <summary>
/// Regenerates amount in damageTaker
/// </summary>
public class Regeneration : MonoBehaviour
{
    [SerializeField] private DamageTaker damageTaker = default;

    [SerializeField] private float regenerationTime = 0;
    [SerializeField] private int regenerationAmount = 0;

    private Coroutine coroutine = null;

    private float timeToRegeneration;

    private bool isAmountChanged = false;

    private void OnEnable()
    {
        damageTaker.AmountChanged += AmountChanged;

        coroutine = StartCoroutine(Regenerate());
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
            
            damageTaker.Regenerate(new Heal(regenerationAmount));            
        }
    }

    private bool CheckIfCanRegenerate()
    {
        timeToRegeneration -= Time.deltaTime;

        if (isAmountChanged || damageTaker.Amount == damageTaker.MaxAmount)
        {
            isAmountChanged = false;

            timeToRegeneration = regenerationTime;

            return false;
        }

        return timeToRegeneration <= 0;
    }

    private void AmountChanged(int amount, int difference)
    {
        isAmountChanged = true;
    }
}
