/// <summary>
/// Health
/// </summary>
public class Health : DamageTaker
{
    /// <summary>
    /// Take damage to this component
    /// </summary>
    /// <param name="damage">damage</param>
    public override Damage TakeDamage(Damage damage)
    {
        if (damage.amount <= 0)
        {
            return damage;
        }

        Damage restDamage = new Damage(damage.amount - amount);

        amount -= damage.amount;
        amount = amount < 0 ? 0 : amount;

        InvokeAmountChanged(amount, -damage.amount);        

        return restDamage;
    }
}
