// Doesn't need to be immutable but why not given the requirements.
public class Ingredient
{
    public readonly double Amount { get; private set; }
    //TODO: Decorator pattern for this one.
    public readonly FoodItem Item { get; private set; }


    public Ingredient(double amount, FoodItem foodItem)
    {
        //throw if foodItem is null. throw if amount is negative.
        this.Amount = amount;
        this.Item = foodItem;
    }


    public override ToString()
    {
        return String.Format("{0} {1}", this.ToFraction(Amount), this.Item.Name);
    }

    #region Fraction Helpers
    //Just for fun. Should be in another class.
    private string ToFraction(double value)
    {
        var result = "";
        if ((value % 1) == 0)
        {
            result = ((int) value).ToString();
        }
        else
        {
            var i = 0;
            do
            {
                i++;
                value *= 10;
            } while ((value % 1) != 0);

            var multiple = (uint) Math.Pow(10, i);
            var gcd = GCD(multiple, (uint) value);
            var numerator = (int)(value / gcd);
            var denominator = (int)(multiple / gcd);
            result = String.Format("{0}/{1}", numerator, denominator);
        }

        return result;
    }

    private uint GCD(uint larger, uint smaller)
    {
        if (larger < smaller)
        {
            var temp = larger;
            larger = smaller;
            smaller = larger;
        }

        while (true)
        {
            uint remainder = larger % smaller;
            if (remainder == 0)
            {
                return smaller;
            }

            larger = smaller;
            smaller = remainder;
        }
    }
    #endregion
}
