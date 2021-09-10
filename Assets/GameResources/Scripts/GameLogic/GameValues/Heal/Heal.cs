using System;

/// <summary>
/// Heal
/// </summary>
[Serializable]
public struct Heal
{
    public AbstractGameValue Value;

    public int Amount => Value.Amount;

    public Heal(int amount)
    {
        Value = new AbstractGameValue(amount);        
    }
}
