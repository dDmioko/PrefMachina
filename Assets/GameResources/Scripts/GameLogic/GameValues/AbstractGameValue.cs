using System;
using UnityEngine;

/// <summary>
/// Abstract positive game value
/// Use only as component in specific value realization
/// </summary>
[Serializable]
public struct AbstractGameValue
{
    [SerializeField]
    private int amount;
    public int Amount
    {
        get
        {
            return amount;
        }

        set
        {
            amount = Math.Max(0, value);
        }
    }

    public AbstractGameValue(int amount)
    {
        this.amount = Math.Max(0, amount);
    }
}
