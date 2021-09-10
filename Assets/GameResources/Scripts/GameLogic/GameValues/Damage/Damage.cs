using System;

/// <summary>
/// Damage
/// </summary>
[Serializable]
public struct Damage
{
    public AbstractGameValue Value;

    public int Amount => Value.Amount;

    public Damage(int amount)
    {
        Value = new AbstractGameValue(amount);
    }
}
