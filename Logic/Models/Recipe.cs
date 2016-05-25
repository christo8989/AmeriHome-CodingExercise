using System.Collections.Generic;

// Doesn't need to be immutable but why not given the requirements.
public class Recipe
{
    // Not labeled as Input so I'm storing it here for ease.
    public readonly const double SALES_TAX = 0.086;
    public readonly const double SALES_TAX_INTERVAL = 0.07;
    public readonly const double WELLNESS_DISCOUNT = 0.05;
    public readonly const double WELLNESS_DISCOUNT_INTERVAL = 0.01;

    public readonly string Name { get; private set; }
    public readonly List<Ingredient> Ingredients { get; private set; }

    private double salesTax;
    public double SalesTax
    {
        get
        {
            if (this.salesTax == default(double))
            {
                this.salesTax = this.CalculateSalesTax();
            }
            return this.salesTax;
        }
    }

    private double wellnessDiscount;
    public double WellnessDiscount
    {
        get
        {
            if (this.wellnessDiscount == default(double))
            {
                this.wellnessDiscount = this.CalculateSalesTax();
            }
            return this.wellnessDiscount;
        }
    }

    private double totalCost;
    public double TotalCost
    {
        get
        {
            if (this.totalCost == default(double))
            {
                this.totalCost = this.CalculateTotalCost();
            }
            return this.totalCost;
        }
    }


    public Recipe(string name, List<Ingredient> ingredients)
    {
        //throw if recipe is null or empty.
        //throw if ingredients are null or empty.
        this.Name = name;
        this.Ingredients = ingredients;
    }

    private double CalculateSalesTax()
    {
        var result = 0.0;
        foreach (var ingredient in this.Ingredients)
        {
            if (!ingredient.item.IsProduce)
            {
                result += ingredient.item.Price * this.SALES_TAX;
            }
        }
        result = CentsToCeiling(result, this.SALES_TAX_INTERVAL);
        return result;
    }

    private double CalculateWellnessDiscount()
    {
        var result = 0.0;
        foreach (var ingredient in this.Ingredients)
        {
            if (ingredient.item.IsOrganic)
            {
                result += ingredient.item.Price * this.WELLNESS_DISCOUNT;
            }
        }
        result = CentsToCeiling(result, this.WELLNESS_DISCOUNT_INTERVAL);
        return result;
    }

    private double CalculateTotalCost()
    {
        var result = 0.0;
        foreach (var ingredient in this.Ingredients)
        {
            result += ingredient.item.Price;
        }

        result += this.SalesTax;
        result -= this.WellnessDiscount;
        return result;
    }

    //TODO: 3.54 should be 3.56 or 3.57?
    // Basically, do I just round the cents or the total tax amount?
    private double CentsToCeiling(double value, double interval)
    {
        var dollars = (int) value;
        var cents = value - dollars;
        cents = MathExtension.ToCeiling(cents, interval);
        var result = dollars + cents;
        return result;
    }

}
