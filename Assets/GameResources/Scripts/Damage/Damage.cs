public struct Damage
{
    private int amount;
    public int Amount
    {
        get
        {
            return amount;
        }

        set
        {
            if (value >= 0) 
            {
                amount = value;
            }
        }
    }
}
