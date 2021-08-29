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

    [SerializeField] protected int amount = 0;
    public int Amount => amount;

    [SerializeField] protected int maxAmount = 0;
    public int MaxAmount => maxAmount;

    protected void InvokeAmountChanged(int amount, int difference)
    {
        AmountChanged?.Invoke(amount, difference);
    }

    public abstract Damage TakeDamage(Damage damage);
}
