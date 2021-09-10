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
            amount = Mathf.Clamp(value, 0, maxAmount);
        }
    }

    [SerializeField] protected int maxAmount = 0;
    public int MaxAmount => maxAmount;

    protected void InvokeAmountChanged(int amount, int difference)
    {
        AmountChanged?.Invoke(amount, difference);
    }

    /// <summary>
    /// Decrease amount of hp in this component
    /// </summary>
    /// <param name="damage">damage</param>
    public abstract Damage TakeDamage(Damage damage);

    /// <summary>
    /// Increase amount of hp in this component
    /// </summary>
    /// <param name="heal"></param>
    public abstract void Heal(Heal heal);
}
