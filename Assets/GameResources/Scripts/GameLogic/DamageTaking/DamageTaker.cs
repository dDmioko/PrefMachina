using System;
using UnityEngine;

/// <summary>
/// Abstract class of damage taker component
/// </summary>
public abstract class DamageTaker : MonoBehaviour
{
    /// <summary>
    /// returns Health amount and difference
    /// </summary>
    public event Action<int, int> AmountChanged;

    [SerializeField] private int amount = 0;
    public int Amount
    {
        get
        {
            return amount;
        }

        protected set
        {
            if (value > maxAmount)
            {
                amount = maxAmount;

                return;
            }

            if (value < 0)
            {
                amount = 0;

                return;
            }

            amount = value;
        }
    }

    [SerializeField] protected int maxAmount = 0;
    public int MaxAmount => maxAmount;

    protected void InvokeAmountChanged(int amount, int difference)
    {
        AmountChanged?.Invoke(amount, difference);
    }

    /// <summary>
    /// Reduce amount of hp in this component
    /// </summary>
    /// <param name="damage">damage</param>
    public abstract Damage TakeDamage(Damage damage);

    /// <summary>
    /// Increase amount of hp in this component
    /// </summary>
    /// <param name="heal"></param>
    public abstract void Regenerate(Heal heal);

    /// <summary>
    /// Increase amount of hp in this component
    /// </summary>
    /// <param name="heal"></param>
    public abstract void Heal(Heal heal);
}
