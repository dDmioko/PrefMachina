using System;
using UnityEngine;

/// <summary>
/// Damage
/// </summary>
[Serializable]
public struct Damage
{
    public int amount;

    public Damage(int amount)
    {
        this.amount = amount > 0 ? amount : 0;
    }
}
